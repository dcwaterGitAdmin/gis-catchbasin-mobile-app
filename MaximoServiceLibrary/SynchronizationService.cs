using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Timers;
using LocalDBLibrary.model;
using MaximoServiceLibrary.model;

namespace MaximoServiceLibrary
{
	public class SynchronizationService
	{
		public bool isOffline { get; set; }

		public bool isInSynchronization { get; set; }

		private Timer synchronizationTimer;

		public SynchronizationDelegateHandler synchronizationDelegate;

		public MaximoUser mxuser;

		public delegate void SynchronizationDelegateHandler(string status, string substatus);

		public SynchronizationService()
		{
			synchronizationDelegate = new SynchronizationDelegateHandler(logSynchronizationStatus);
		}

		public void logSynchronizationStatus(string status, string substatus)
		{
			AppContext.Log.Info($"[MX] syncronization status:{status}, substatus:{substatus}");
		}

		public void startSyncronizationTimer()
		{
			// every 10 seconds / minutes
			startSyncronizationTimer(10000);
		}

		public void startSyncronizationTimer(double interval)
		{
			synchronizationTimer = new Timer(interval);
			synchronizationTimer.Elapsed += onSyncTimerElapsed;
			synchronizationTimer.Enabled = true;

			triggerSynchronization();
		}

		public void stopSyncronizationTimer()
		{
			synchronizationTimer.Enabled = false;
		}

		public void onSyncTimerElapsed(Object source, ElapsedEventArgs e)
		{
			triggerSynchronization();
		}

		public void triggerSynchronization()
		{
			if (isOffline)
			{
				synchronizationDelegate("SYNC_OFFLINE", "The synchronization is set to be offline, returning");
				return;
			}

			if (isInSynchronization)
			{
				synchronizationDelegate("SYNC_IN_PROGRESS", "The synchronization is already running");
				return;
			}

			AppContext.Log.Warn("The Elapsed event was raised ");

			Task t = new Task(() => { synchronizeInBackground(); });

			t.Start();
		}

		public async void synchronizeInBackground()
		{
			synchronizationDelegate("SYNC_STARTED", "started synchronization in background");
			try
			{
				isInSynchronization = true;
				synchronizationTimer.Enabled = false;

				bool isOnline = AppContext.maximoService.checkIsOnline(mxuser.userName, mxuser.password);
				if (!isOnline)
				{
					synchronizationDelegate("MAXIMO_OFFLINE", "Maximo service is offline, sleeping...");
					return;
				}

				synchronizationDelegate("SYNC_IN_PROGRESS", "fetching all work orders from Maximo...");
				List<MaximoWorkOrder> workOrdersFromMaximo = fetchAllWorkOrdersFromMaximo();
                //List<MaximoWorkOrder> workOrdersFromMaximo = new List<MaximoWorkOrder>();
                synchronizationDelegate("SYNC_IN_PROGRESS", "fetched " + workOrdersFromMaximo.Count + " workorders from Maximo");

				synchronizationDelegate("SYNC_IN_PROGRESS", "fetching all work orders from Local...");
				// TODO Assuming that when a user changes crew, we will delete all work orders of previous crew
				IEnumerable<MaximoWorkOrder> workOrdersFromLocal = AppContext.workOrderRepository.findAll();
				synchronizationDelegate("SYNC_IN_PROGRESS", "fetched " + workOrdersFromLocal.Count() + " workorders from Local");

				// sync the work orders
				AppContext.Log.Debug($"[MX] BEGIN to synchronize workOrdersFromMaximo.");
				foreach (var woFromMaximo in workOrdersFromMaximo)
				{
					try
					{
						AppContext.Log.Debug($"[MX] BEGIN to synchronize work order : {woFromMaximo.wonum}");

						MaximoWorkOrder woFromLocal = workOrdersFromLocal.FirstOrDefault(wo => wo.wonum == woFromMaximo.wonum);

						synchronizeWorkOrder(woFromMaximo, woFromLocal);

						AppContext.Log.Debug($"[MX] END to synchronize work order : {woFromMaximo.wonum}");
					}
					catch (Exception ex)
					{
						AppContext.Log.Error(
							$"[MX] FAILED to synchronize work order {woFromMaximo.wonum} : {ex.ToString()}");
					}
				}

				AppContext.Log.Debug($"[MX] END to synchronize workOrdersFromMaximo.");

				// POST CREATED work orders to Maximo
				AppContext.Log.Debug($"[MX] BEGIN to synchronize workOrdersFromLocal.");
				workOrdersFromLocal = AppContext.workOrderRepository.findAll();
				foreach (var woFromLocal in workOrdersFromLocal)
				{
					try
					{
						AppContext.Log.Debug($"[MX] woFromLocal.wonum: {woFromLocal.wonum}, woFromLocal.completed: {woFromLocal.completed}, woFromLocal.syncronizationStatus: {woFromLocal.syncronizationStatus}.");

						if (woFromLocal.completed)
						{
							synchronizationDelegate("POST_WORK_ORDER", $"posting work order: [{(woFromLocal.wonum == null ? woFromLocal.Id.ToString() : woFromLocal.wonum)}]");

							AppContext.Log.Info($"[MX] woFromLocal is completed so postWorkOrderToMaximo wonum: {woFromLocal.wonum}.");
							postWorkOrderToMaximo(woFromLocal);
							AppContext.Log.Info($"[MX] posted woFromLocal. wonum: {woFromLocal.wonum}.");
						}
					}
					catch (Exception ex)
					{
						AppContext.Log.Error($"[MX] FAILED to synchronize woFromLocal {woFromLocal.wonum} : {ex.ToString()}");
						AppContext.Log.Error(ex.StackTrace);
						// TODO remove failure sync status
						woFromLocal.failed = true;
						AppContext.workOrderRepository.upsert(woFromLocal);
					}
				}

				AppContext.Log.Debug($"[MX] END to synchronize workOrdersFromLocal.");

				// DELETE local work orders which are not received from Maximo
				AppContext.Log.Debug($"[MX] BEGIN to delete local work orders that are  not received from Maximo.");
				workOrdersFromLocal = AppContext.workOrderRepository.findAll();
				foreach (var woFromLocal in workOrdersFromLocal)
				{
					try
					{
						AppContext.Log.Debug($"[MX] woFromLocal.wonum: {woFromLocal.wonum}, woFromLocal.completed: {woFromLocal.completed}, woFromLocal.syncronizationStatus: {woFromLocal.syncronizationStatus}.");

						MaximoWorkOrder woFromMaximo = workOrdersFromMaximo.FirstOrDefault(wo => wo.wonum == woFromLocal.wonum);
						if (woFromMaximo == null && woFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED)
						{
							AppContext.workOrderRepository.delete(woFromLocal);
							AppContext.Log.Debug($"[MX] deleted woFromLocal. wonum: {woFromLocal.wonum}.");
						}
					}
					catch (Exception ex)
					{
						AppContext.Log.Error(ex.StackTrace);
					}
				}

				AppContext.Log.Debug($"[MX] END to delete local work orders that are  not received from Maximo.");
			}
			catch (Exception ex)
			{
				AppContext.Log.Error(ex.StackTrace);
			}
			finally
			{
				synchronizationDelegate("SYNC_FINISHED", "Maximo synchronization complete!");

				isInSynchronization = false;
				synchronizationTimer.Enabled = true;
			}
		}

		private void synchronizeWorkOrder(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
		{
			// step 1 - check if there is a local work order
			if (woFromLocal == null)
			{
				AppContext.Log.Info($"[MX] No local copy found for work order : {woFromMaximo.wonum}. Maximo work order will be persisted in local DB");

				woFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
				AppContext.workOrderRepository.upsert(woFromMaximo);
				return;
			}

			// step 2 - merge maximo work order with local work order and save local merged workorder in DB
			AppContext.Log.Debug($"[MX] local work order Id : [{woFromLocal.Id}], IsCompleted : [{woFromLocal.completed}], status : [{woFromLocal.syncronizationStatus}] ");

			mergeWorkOrderFromMaximoToLocal(woFromMaximo, woFromLocal, false);

			// merge work order child entities between Maximo and Local work orders
			// todo DELETED sync status
			// todo doclinks
			List<MaximoWorkOrderSpec> freshWorkOrderSpecList = generateFreshWorkOrderSpecList(woFromMaximo, woFromLocal);
			List<MaximoWorkOrderFailureReport> freshWorkOrderFailureReportList = generateFreshWorkOrderFailureReportList(woFromMaximo, woFromLocal);
			List<MaximoLabTrans> freshWorkOrderLabTransList = generateFreshWorkOrderLabTransList(woFromMaximo, woFromLocal);
			List<MaximoToolTrans> freshWorkOrderToolTransList = generateFreshWorkOrderToolTransList(woFromMaximo, woFromLocal);

			woFromLocal.workorderspec = freshWorkOrderSpecList;
			woFromLocal.failurereport = freshWorkOrderFailureReportList;
			woFromLocal.labtrans = freshWorkOrderLabTransList;
			woFromLocal.tooltrans = freshWorkOrderToolTransList;

			AppContext.workOrderRepository.upsert(woFromLocal);
		}

		private void mergeWorkOrderFromMaximoToLocal(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal, bool updatedByUs)
		{
			//means item is changed in maximo side
			if (woFromMaximo._rowstamp != woFromLocal._rowstamp)
			{
				AppContext.Log.Debug($"[MX] work order is changed in Maximo. wonum : [{woFromMaximo.wonum}], local status : [{woFromLocal.syncronizationStatus}]");

				if ((woFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED) || updatedByUs)
				{
					AppContext.Log.Debug($"[MX] work order from Maximo is going to be overwritten to local. wonum : [{woFromMaximo.wonum}], local status : [{woFromLocal.syncronizationStatus}]");

					// merge changes from Maximo to Local entity
					woFromLocal.wonum = woFromMaximo.wonum;
					woFromLocal.workorderid = woFromMaximo.workorderid;
					woFromLocal._rowstamp = woFromMaximo._rowstamp;
					woFromLocal.status = woFromMaximo.status;
					woFromLocal.np_statusmemo = woFromMaximo.np_statusmemo;
					woFromLocal.statusdate = woFromMaximo.statusdate;
					woFromLocal.assetnum = woFromMaximo.assetnum;
					woFromLocal.remarkdesc = woFromMaximo.remarkdesc;
					woFromLocal.problemcode = woFromMaximo.problemcode;
				}
				else if (woFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED ||
				         woFromLocal.syncronizationStatus == SyncronizationStatus.CONFLICTED)
				{
					// todo - check how to solve CONFLICT case!!!
					AppContext.Log.Warn($"[MX] CONFLICT!! work order is changed both in Maximo and in local db. wonum : [{woFromMaximo.wonum}], local status : [{woFromLocal.syncronizationStatus}]");

					woFromLocal.syncronizationStatus = SyncronizationStatus.CONFLICTED;
				}
			}

			if (woFromMaximo.workorderspec != null && woFromLocal.workorderspec != null)
			{
				foreach (var woSpecFromMaximo in woFromMaximo.workorderspec)
				{
					MaximoWorkOrderSpec woSpecFromLocal = woFromLocal.workorderspec.FirstOrDefault(wospec => wospec.assetattrid == woSpecFromMaximo.assetattrid);
					if (woSpecFromLocal != null)
					{
						woSpecFromLocal._rowstamp = woSpecFromMaximo._rowstamp;
					}
				}
			}
		}

		private void postWorkOrderToMaximo(MaximoWorkOrder woFromLocal)
		{
			List<MaximoWorkOrderSpec> freshWorkOrderSpecList = woFromLocal.workorderspec;
			List<MaximoWorkOrderFailureReport> freshWorkOrderFailureReportList = woFromLocal.failurereport;
			List<MaximoLabTrans> freshWorkOrderLabTransList = woFromLocal.labtrans;
			List<MaximoToolTrans> freshWorkOrderToolTransList = woFromLocal.tooltrans;

			AppContext.Log.Info($"[MX] Entered postWorkOrderToMaximo. wonum: {woFromLocal.wonum}, completed: {woFromLocal.completed}, syncronizationStatus: {woFromLocal.syncronizationStatus}, retryCount: {woFromLocal.retryCount}");

			if (woFromLocal.completed)
			{
				if (woFromLocal.retryCount > 3)
				{
					AppContext.Log.Error($"Work order retry count reached maximum, give up synchronization: {woFromLocal.wonum}");
					return;
				}

				woFromLocal.retryCount = woFromLocal.retryCount + 1;
				AppContext.workOrderRepository.upsert(woFromLocal);
				
				if (woFromLocal.syncronizationStatus == SyncronizationStatus.CREATED)
				{
					AppContext.Log.Debug($"[MX] Calling maximoService.createWorkOrder. db Id: {woFromLocal.Id}");
					// in the first create call to Maximo, we have to clear the related entities
					woFromLocal.workorderspec = null;
					woFromLocal.failurereport = null;
					woFromLocal.labtrans = null;
					woFromLocal.tooltrans = null;
					woFromLocal.doclink = null;

					MaximoWorkOrder woFreshFromMaximo = AppContext.maximoService.createWorkOrder(woFromLocal);
					mergeMaximoWorkOrderSpecsToLocalWorkOrder(woFromLocal, freshWorkOrderSpecList, woFreshFromMaximo);
					mergeMaximoWorkOrderFailureReportsToLocalWorkOrder(woFromLocal, freshWorkOrderFailureReportList, woFreshFromMaximo);
					mergeWorkOrderFromMaximoToLocal(woFreshFromMaximo, woFromLocal, true);

					woFromLocal.labtrans = freshWorkOrderLabTransList;
					woFromLocal.tooltrans = freshWorkOrderToolTransList;
					//woFinalToBeSaved.doclink = freshWorkOrderDocLinksList;
					AppContext.workOrderRepository.upsert(woFromLocal);


					AppContext.Log.Debug($"[MX] Calling maximoService.updateWorkOrder with enhanced woSpec and failureReport lists. wonum: {woFromLocal.wonum}");
					woFreshFromMaximo = AppContext.maximoService.updateWorkOrder(woFromLocal);
					mergeWorkOrderFromMaximoToLocal(woFreshFromMaximo, woFromLocal, true);
					AppContext.workOrderRepository.upsert(woFromLocal);
					AppContext.Log.Debug($"[MX] Called maximoService.updateWorkOrder and WO re-fetched. wonum: {woFromLocal.wonum}");


					AppContext.Log.Debug($"[MX] Calling maximoService.updateWorkOrderActuals with enhanced freshWorkOrderLabTransList and freshWorkOrderToolTransList. wonum: {woFromLocal.wonum}");
					woFreshFromMaximo = AppContext.maximoService.updateWorkOrderActuals(woFromLocal);
					mergeWorkOrderFromMaximoToLocal(woFreshFromMaximo, woFromLocal, true);
					AppContext.workOrderRepository.upsert(woFromLocal);
					AppContext.Log.Debug($"[MX] Called maximoService.updateWorkOrderActuals and WO re-fetched. wonum: {woFromLocal.wonum}");
				}
				else if (woFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED)
				{
					AppContext.Log.Debug($"[MX] Calling maximoService.updateWorkOrder because WO is completed and SYNC status is MODIFIED (all childs are fresh). wonum: {woFromLocal.wonum}");
					MaximoWorkOrder woFreshFromMaximo = AppContext.maximoService.updateWorkOrder(woFromLocal);
					mergeWorkOrderFromMaximoToLocal(woFreshFromMaximo, woFromLocal, true);
					AppContext.workOrderRepository.upsert(woFromLocal);
					AppContext.Log.Debug($"[MX] Called maximoService.updateWorkOrder and WO re-fetched. wonum: {woFromLocal.wonum}");

					AppContext.Log.Debug($"[MX] Calling maximoService.updateWorkOrderActuals (all childs are fresh). wonum: {woFromLocal.wonum}");
					woFreshFromMaximo = AppContext.maximoService.updateWorkOrderActuals(woFromLocal);
					mergeWorkOrderFromMaximoToLocal(woFreshFromMaximo, woFromLocal, true);
					AppContext.workOrderRepository.upsert(woFromLocal);
					AppContext.Log.Debug($"[MX] Called maximoService.updateWorkOrderActuals and WO re-fetched. wonum: {woFromLocal.wonum}");
				}

				//post follow up work orders
				if (woFromLocal.followups != null && woFromLocal.followups.Count > 0)
				{
					AppContext.Log.Info($"[MX] WO has {woFromLocal.followups.Count()} followups. wonum: {woFromLocal.wonum}");
					List<MaximoWorkOrder> freshFollowup = new List<MaximoWorkOrder>();
					foreach (var followupWorkOrder in woFromLocal.followups)
					{
						followupWorkOrder.origrecordid = woFromLocal.wonum;
						AppContext.Log.Debug($"[MX] Calling maximoService.createWorkOrder for followupWorkOrder. wonum: {woFromLocal.wonum}, followupWorkOrder.Id: {followupWorkOrder.Id}");
						MaximoWorkOrder fetchedFollowupWO = AppContext.maximoService.createWorkOrder(followupWorkOrder);
						AppContext.Log.Debug($"[MX] Called maximoService.createWorkOrder for followupWorkOrder. wonum: {woFromLocal.wonum}, followupWorkOrder.Id: {followupWorkOrder.Id}");
						freshFollowup.Add(fetchedFollowupWO);
					}

					AppContext.Log.Debug($"[MX] freshFollowup list set to woFinalToBeSaved.followups. wonum: {woFromLocal.wonum}");
					woFromLocal.followups = freshFollowup;
					AppContext.workOrderRepository.upsert(woFromLocal);
				}

				woFromLocal.completed = false;
				woFromLocal.failed = false;
				woFromLocal.syncronizationStatus = SyncronizationStatus.SYNCED;
				AppContext.workOrderRepository.upsert(woFromLocal);
			}
		}

		private void mergeMaximoWorkOrderFailureReportsToLocalWorkOrder(MaximoWorkOrder woFromLocal, List<MaximoWorkOrderFailureReport> freshWorkOrderFailureReportList, MaximoWorkOrder woFreshFromMaximo)
		{
			// merge failurerport entities if returned from Maximo
			List<MaximoWorkOrderFailureReport> tempWorkOrderFailureReportList = new List<MaximoWorkOrderFailureReport>();
			if (freshWorkOrderFailureReportList != null)
			{
				AppContext.Log.Debug($"[MX] Re-fetched WO has failureReport. wonum: {woFromLocal.wonum}");
				foreach (var failurereportFromLocal in freshWorkOrderFailureReportList)
				{
					var failurereportFromMaximo = woFreshFromMaximo.failurereport.FirstOrDefault(failurerport => failurerport.type == failurereportFromLocal.type);
					if (failurereportFromMaximo != null)
					{
						AppContext.Log.Debug($"[MX] woFailureReport found locally, failurecode set to final failureReport. wonum : {woFromLocal.wonum}, failureReport.type : {failurereportFromLocal.type}");
						failurereportFromMaximo.failurecode = failurereportFromLocal.failurecode;
						tempWorkOrderFailureReportList.Add(failurereportFromMaximo);
					}
					else
					{
						tempWorkOrderFailureReportList.Add(failurereportFromLocal);
					}
				}
			}
			else
			{
				tempWorkOrderFailureReportList = woFreshFromMaximo.failurereport;
			}

			woFromLocal.failurereport = tempWorkOrderFailureReportList;
		}

		private void mergeMaximoWorkOrderSpecsToLocalWorkOrder(MaximoWorkOrder woFromLocal, List<MaximoWorkOrderSpec> freshWorkOrderSpecList, MaximoWorkOrder woFreshFromMaximo)
		{
			AppContext.Log.Info($"[MX] Called maximoService.createWorkOrder and WO re-fetched: {woFromLocal.wonum}");

			// in the second  call to Maximo, we have to put the related entities in the request
			// merge workorderspec values to workorder fetched from Maximo after creation
			List<MaximoWorkOrderSpec> tempWorkOrderSpecList = new List<MaximoWorkOrderSpec>();
			if (freshWorkOrderSpecList != null)
			{
				AppContext.Log.Debug($"[MX] Re-fetched WO has woSpecs. wonum: {woFromLocal.wonum}");
				foreach (var workOrderSpecFromLocal in freshWorkOrderSpecList)
				{
					var workorderSpecFromMaximo = woFreshFromMaximo.workorderspec.FirstOrDefault(workorderSpec => workorderSpec.assetattrid == workOrderSpecFromLocal.assetattrid);
					if (workorderSpecFromMaximo != null)
					{
						AppContext.Log.Debug($"[MX] woSpec found locally, alnvalue and numvalue are set to final woSpec. wonum : {woFromLocal.wonum}, woSpec.assetattrid : {workOrderSpecFromLocal.assetattrid}");
						workorderSpecFromMaximo.alnvalue = workOrderSpecFromLocal.alnvalue;
						workorderSpecFromMaximo.numvalue = workOrderSpecFromLocal.numvalue;
						tempWorkOrderSpecList.Add(workorderSpecFromMaximo);
					}
					else
					{
						tempWorkOrderSpecList.Add(workOrderSpecFromLocal);
					}
				}
			}
			else
			{
				AppContext.Log.Debug($"[MX] Re-fetched WO has no woSpec so freshWorkOrderSpecList set to final woSpec list of WO. wonum: {woFromLocal.wonum}");
				tempWorkOrderSpecList = woFreshFromMaximo.workorderspec;
			}

			woFromLocal.workorderspec = tempWorkOrderSpecList;
		}


		public List<MaximoWorkOrderSpec> generateFreshWorkOrderSpecList(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
		{
			List<MaximoWorkOrderSpec> freshWorkOrderSpecList = new List<MaximoWorkOrderSpec>();

			if (woFromMaximo.workorderspec != null)
			{
				foreach (var woSpecFromMaximo in woFromMaximo.workorderspec)
				{
					MaximoWorkOrderSpec woSpecFromLocal = null;
					if (woFromLocal != null)
					{
						woSpecFromLocal = woFromLocal.workorderspec.Find(wospec => wospec.workorderspecid == woSpecFromMaximo.workorderspecid);
					}

					// Local copy found
					if (woSpecFromLocal != null)
					{
						//means item is changed in maximo side
						if (woSpecFromMaximo._rowstamp != woSpecFromLocal._rowstamp)
						{
							if (woSpecFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED)
							{
								woSpecFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
								freshWorkOrderSpecList.Add(woSpecFromMaximo);
							}
							else if (woSpecFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED ||
							         woSpecFromLocal.syncronizationStatus == SyncronizationStatus.CONFLICTED)
							{
								woSpecFromLocal.syncronizationStatus = SyncronizationStatus.CONFLICTED;
								freshWorkOrderSpecList.Add(woSpecFromLocal);
							}
						}
						//means item is not changed in maximo side
						else
						{
							// Add to fresh list, localCopies irregardless of SyncronizationStatus
							freshWorkOrderSpecList.Add(woSpecFromLocal);
						}

						woFromLocal.workorderspec.Remove(woSpecFromLocal);
					}
					//Local copy not found
					else
					{
						woSpecFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
						freshWorkOrderSpecList.Add(woSpecFromMaximo);
					}
				}
			}


			// if there are still entities in CREATED status in the local copy, add them to fresh list. previously SYNCED entities will be removed
			if (woFromLocal != null && woFromLocal.workorderspec != null)
			{
				foreach (var woSpecFromLocal in woFromLocal.workorderspec)
				{
					// We only put CREATED ones. SYNCED one means it is deleted from maximo side so we dont put into the list in order to delete from local
					if (woSpecFromLocal.syncronizationStatus == SyncronizationStatus.CREATED)
					{
						freshWorkOrderSpecList.Add(woSpecFromLocal);
					}
				}
			}

			return freshWorkOrderSpecList;
		}

		public List<MaximoWorkOrderFailureReport> generateFreshWorkOrderFailureReportList(MaximoWorkOrder woFromMaximo,
			MaximoWorkOrder woFromLocal)
		{
			List<MaximoWorkOrderFailureReport> freshWorkOrderFailureReportList =
				new List<MaximoWorkOrderFailureReport>();

			if (woFromMaximo.failurereport != null)
			{
				foreach (var woFailureReportFromMaximo in woFromMaximo.failurereport)
				{
					MaximoWorkOrderFailureReport woFailureReportFromLocal = null;
					if (woFromLocal != null)
					{
						woFailureReportFromLocal = woFromLocal.failurereport.Find(wosfr =>
							wosfr.failurereportid == woFailureReportFromMaximo.failurereportid);
					}

					// Local copy found
					if (woFailureReportFromLocal != null)
					{
						//means item is changed in maximo side
						if (woFailureReportFromMaximo._rowstamp != woFailureReportFromLocal._rowstamp)
						{
							if (woFailureReportFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED)
							{
								woFailureReportFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
								freshWorkOrderFailureReportList.Add(woFailureReportFromMaximo);
							}
							else if (woFailureReportFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED ||
							         woFailureReportFromLocal.syncronizationStatus == SyncronizationStatus.CONFLICTED)
							{
								woFailureReportFromLocal.syncronizationStatus = SyncronizationStatus.CONFLICTED;
								freshWorkOrderFailureReportList.Add(woFailureReportFromLocal);
							}
						}
						//means item is not changed in maximo side
						else
						{
							// Add to fresh list, localCopies irregardless of SyncronizationStatus
							freshWorkOrderFailureReportList.Add(woFailureReportFromLocal);
						}

						woFromLocal.failurereport.Remove(woFailureReportFromLocal);
					}
					//Local copy not found
					else
					{
						woFailureReportFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
						freshWorkOrderFailureReportList.Add(woFailureReportFromMaximo);
					}
				}
			}


			// if there are still entities in CREATED status in the local copy, add them to fresh list. previously SYNCED entities will be removed
			if (woFromLocal != null && woFromLocal.failurereport != null)
			{
				foreach (var woFailureReportFromLocal in woFromLocal.failurereport)
				{
					// We only put CREATED ones. SYNCED one means it is deleted from maximo side so we dont put into the list in order to delete from local
					if (woFailureReportFromLocal.syncronizationStatus == SyncronizationStatus.CREATED)
					{
						freshWorkOrderFailureReportList.Add(woFailureReportFromLocal);
					}
				}
			}

			return freshWorkOrderFailureReportList;
		}

		public List<MaximoLabTrans> generateFreshWorkOrderLabTransList(MaximoWorkOrder woFromMaximo,
			MaximoWorkOrder woFromLocal)
		{
			List<MaximoLabTrans> freshWorkOrderLabTransList = new List<MaximoLabTrans>();

			if (woFromMaximo.labtrans != null)
			{
				foreach (var woLabTransFromMaximo in woFromMaximo.labtrans)
				{
					MaximoLabTrans woLabTransFromLocal = null;
					if (woFromLocal != null)
					{
						woLabTransFromLocal =
							woFromLocal.labtrans.Find(woslt => woslt.labtransid == woLabTransFromMaximo.labtransid);
					}

					// Local copy found
					if (woLabTransFromLocal != null)
					{
						//means item is changed in maximo side
						if (woLabTransFromMaximo._rowstamp != woLabTransFromLocal._rowstamp)
						{
							if (woLabTransFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED)
							{
								woLabTransFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
								freshWorkOrderLabTransList.Add(woLabTransFromMaximo);
							}
							else if (woLabTransFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED ||
							         woLabTransFromLocal.syncronizationStatus == SyncronizationStatus.CONFLICTED)
							{
								woLabTransFromLocal.syncronizationStatus = SyncronizationStatus.CONFLICTED;
								freshWorkOrderLabTransList.Add(woLabTransFromLocal);
							}
						}
						//means item is not changed in maximo side
						else
						{
							// Add to fresh list, localCopies irregardless of SyncronizationStatus
							freshWorkOrderLabTransList.Add(woLabTransFromLocal);
						}

						woFromLocal.labtrans.Remove(woLabTransFromLocal);
					}
					//Local copy not found
					else
					{
						woLabTransFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
						freshWorkOrderLabTransList.Add(woLabTransFromMaximo);
					}
				}
			}


			// if there are still entities in CREATED status in the local copy, add them to fresh list. previously SYNCED entities will be removed
			if (woFromLocal != null && woFromLocal.labtrans != null)
			{
				foreach (var woLabTransFromLocal in woFromLocal.labtrans)
				{
					// We only put CREATED ones. SYNCED one means it is deleted from maximo side so we dont put into the list in order to delete from local
					if (woLabTransFromLocal.syncronizationStatus == SyncronizationStatus.CREATED)
					{
						freshWorkOrderLabTransList.Add(woLabTransFromLocal);
					}
				}
			}

			return freshWorkOrderLabTransList;
		}

		public List<MaximoToolTrans> generateFreshWorkOrderToolTransList(MaximoWorkOrder woFromMaximo,
			MaximoWorkOrder woFromLocal)
		{
			List<MaximoToolTrans> freshWorkOrderToolTransList = new List<MaximoToolTrans>();

			if (woFromMaximo.tooltrans != null)
			{
				foreach (var woToolTransFromMaximo in woFromMaximo.tooltrans)
				{
					MaximoToolTrans woToolTransFromLocal = null;
					if (woFromLocal != null)
					{
						woToolTransFromLocal = woFromLocal.tooltrans.Find(wostt =>
							wostt.tooltransid == woToolTransFromMaximo.tooltransid);
					}

					// Local copy found
					if (woToolTransFromLocal != null)
					{
						//means item is changed in maximo side
						if (woToolTransFromMaximo._rowstamp != woToolTransFromLocal._rowstamp)
						{
							if (woToolTransFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED)
							{
								woToolTransFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
								freshWorkOrderToolTransList.Add(woToolTransFromMaximo);
							}
							else if (woToolTransFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED ||
							         woToolTransFromLocal.syncronizationStatus == SyncronizationStatus.CONFLICTED)
							{
								woToolTransFromLocal.syncronizationStatus = SyncronizationStatus.CONFLICTED;
								freshWorkOrderToolTransList.Add(woToolTransFromLocal);
							}
						}
						//means item is not changed in maximo side
						else
						{
							// Add to fresh list, localCopies irregardless of SyncronizationStatus
							freshWorkOrderToolTransList.Add(woToolTransFromLocal);
						}

						woFromLocal.tooltrans.Remove(woToolTransFromLocal);
					}
					//Local copy not found
					else
					{
						woToolTransFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
						freshWorkOrderToolTransList.Add(woToolTransFromMaximo);
					}
				}
			}


			// if there are still entities in CREATED status in the local copy, add them to fresh list. previously SYNCED entities will be removed
			if (woFromLocal != null && woFromLocal.tooltrans != null)
			{
				foreach (var woToolTransFromLocal in woFromLocal.tooltrans)
				{
					// We only put CREATED ones. SYNCED one means it is deleted from maximo side so we dont put into the list in order to delete from local
					if (woToolTransFromLocal.syncronizationStatus == SyncronizationStatus.CREATED)
					{
						freshWorkOrderToolTransList.Add(woToolTransFromLocal);
					}
				}
			}

			return freshWorkOrderToolTransList;
		}

		public List<MaximoDocLinks> generateFreshWorkOrderDocLinksList(MaximoWorkOrder woFromMaximo,
			MaximoWorkOrder woFromLocal)
		{
			List<MaximoDocLinks> freshWorkOrderDocLinksList = new List<MaximoDocLinks>();

			if (woFromMaximo.doclink != null)
			{
				foreach (var woDockLinkFromMaximo in woFromMaximo.doclink)
				{
					MaximoDocLinks woDocLinkFromLocal = null;
					if (woFromLocal != null)
					{
						// TODO woDocLinkFromLocal = woFromLocal.doclinks.Find(wosdl => wosdl.doclinksid == woDockLinkFromMaximo.doclinksid);
					}

					// Local copy found
					if (woDocLinkFromLocal != null)
					{
						//means item is changed in maximo side
						if (woDockLinkFromMaximo._rowstamp != woDocLinkFromLocal._rowstamp)
						{
							if (woDocLinkFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED)
							{
								woDockLinkFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
								freshWorkOrderDocLinksList.Add(woDockLinkFromMaximo);
							}
							else if (woDocLinkFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED ||
							         woDocLinkFromLocal.syncronizationStatus == SyncronizationStatus.CONFLICTED)
							{
								woDocLinkFromLocal.syncronizationStatus = SyncronizationStatus.CONFLICTED;
								freshWorkOrderDocLinksList.Add(woDocLinkFromLocal);
							}
						}
						//means item is not changed in maximo side
						else
						{
							// Add to fresh list, localCopies irregardless of SyncronizationStatus
							freshWorkOrderDocLinksList.Add(woDocLinkFromLocal);
						}

						woFromLocal.doclink.Remove(woDocLinkFromLocal);
					}
					//Local copy not found
					else
					{
						woDockLinkFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
						freshWorkOrderDocLinksList.Add(woDockLinkFromMaximo);
					}
				}
			}


			// if there are still entities in CREATED status in the local copy, add them to fresh list. previously SYNCED entities will be removed
			if (woFromLocal != null && woFromLocal.doclink != null)
			{
				foreach (var woDocLinkFromLocal in woFromLocal.doclink)
				{
					// We only put CREATED ones. SYNCED one means it is deleted from maximo side so we dont put into the list in order to delete from local
					if (woDocLinkFromLocal.syncronizationStatus == SyncronizationStatus.CREATED)
					{
						freshWorkOrderDocLinksList.Add(woDocLinkFromLocal);
					}
				}
			}

			return freshWorkOrderDocLinksList;
		}

		public List<MaximoAssetSpec> generateFreshAssetSpecList(MaximoWorkOrder woFromMaximo,
			MaximoWorkOrder woFromLocal)
		{
			//MaximoAsset freshWorkOrderAsset = new MaximoAsset();
			List<MaximoAssetSpec> freshAssetSpecList = new List<MaximoAssetSpec>();

			if (woFromMaximo.asset != null && woFromMaximo.asset.assetspec != null)
			{
				foreach (var woAssetSpecFromMaximo in woFromMaximo.asset.assetspec)
				{
					MaximoAssetSpec woAssetSpecFromLocal = null;
					if (woFromLocal != null && woFromLocal.asset != null)
					{
						woAssetSpecFromLocal = woFromLocal.asset.assetspec.Find(woas =>
							woas.assetspecid == woAssetSpecFromMaximo.assetspecid);
					}

					// Local copy found
					if (woAssetSpecFromLocal != null)
					{
						//means item is changed in maximo side
						if (woAssetSpecFromMaximo._rowstamp != woAssetSpecFromLocal._rowstamp)
						{
							if (woAssetSpecFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED)
							{
								woAssetSpecFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
								freshAssetSpecList.Add(woAssetSpecFromMaximo);
							}
							else if (woAssetSpecFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED ||
							         woAssetSpecFromLocal.syncronizationStatus == SyncronizationStatus.CONFLICTED)
							{
								woAssetSpecFromLocal.syncronizationStatus = SyncronizationStatus.CONFLICTED;
								freshAssetSpecList.Add(woAssetSpecFromLocal);
							}
						}
						//means item is not changed in maximo side
						else
						{
							// Add to fresh list, localCopies irregardless of SyncronizationStatus
							freshAssetSpecList.Add(woAssetSpecFromLocal);
						}

						woFromLocal.asset.assetspec.Remove(woAssetSpecFromLocal);
					}
					//Local copy not found
					else
					{
						woAssetSpecFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
						freshAssetSpecList.Add(woAssetSpecFromMaximo);
					}
				}
			}


			// if there are still entities in CREATED status in the local copy, add them to fresh list. previously SYNCED entities will be removed
			if (woFromLocal != null && woFromLocal.asset != null && woFromLocal.asset.assetspec != null)
			{
				foreach (var woAssetSpecLocal in woFromLocal.asset.assetspec)
				{
					// We only put CREATED ones. SYNCED one means it is deleted from maximo side so we dont put into the list in order to delete from local
					if (woAssetSpecLocal.syncronizationStatus == SyncronizationStatus.CREATED)
					{
						freshAssetSpecList.Add(woAssetSpecLocal);
					}
				}
			}

			return freshAssetSpecList;
		}


		public MaximoAsset synchAsset(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
		{
			MaximoAsset woAssetFromMaximo = woFromMaximo.asset;
			MaximoAsset woAssetFromLocal = null;
			if (woFromLocal != null)
			{
				woAssetFromLocal = woFromLocal.asset;
			}

			MaximoAsset woAssetFinalToBeSaved = woAssetFromMaximo;

			// There exists a remote copy for woAsset
			if (woAssetFromMaximo != null)
			{
				// There exists a Local copy for woAsset
				if (woAssetFromLocal != null)
				{
					// means item is changed in maximo side
					if (woAssetFromMaximo._rowstamp != woAssetFromMaximo._rowstamp)
					{
						if (woAssetFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED)
						{
							woAssetFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
							woAssetFromMaximo.Id = woAssetFromLocal.Id;
						}
						else if (woAssetFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED ||
						         woAssetFromLocal.syncronizationStatus == SyncronizationStatus.CONFLICTED)
						{
							woAssetFromLocal.syncronizationStatus = SyncronizationStatus.CONFLICTED;
							woAssetFinalToBeSaved = woAssetFromLocal;
						}
					}
					//means item is not changed in maximo side
					else
					{
						woAssetFinalToBeSaved = woAssetFromLocal;
					}
				}
				// There is no Local copy for woAsset
				else
				{
					woAssetFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
				}
			}
			// There is no woAsset in remote
			else
			{
				// There exists a Local copy for woAsset
				if (woAssetFromLocal != null)
				{
					//todo EG - check this line
					woAssetFinalToBeSaved = woAssetFromLocal;

					if (woAssetFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED)
					{
						// woAssetFinalToBeSaved is already set to woAssetFromMaximo and it is null;
					}
					else if (woAssetFromLocal.syncronizationStatus == SyncronizationStatus.CREATED)
					{
						woAssetFinalToBeSaved = woAssetFromLocal;
					}
				}
			}

			if (woAssetFinalToBeSaved != null)
			{
				List<MaximoAssetSpec> freshAssetSpecList = generateFreshAssetSpecList(woFromMaximo, woFromLocal);
				woAssetFinalToBeSaved.assetspec = freshAssetSpecList;
				if (woAssetFinalToBeSaved.syncronizationStatus == SyncronizationStatus.CREATED)
				{
					// Call createAsset
					woAssetFinalToBeSaved.assetspec = null;
					woAssetFinalToBeSaved = AppContext.maximoService.createAsset(woAssetFinalToBeSaved);

					// merge asssetspec values to assset fetched from MAximo after creation
					if (woAssetFinalToBeSaved.assetspec != null)
					{
						foreach (var assetSpecFromLocal in freshAssetSpecList)
						{
							var assetSpecFromMaximo = woAssetFinalToBeSaved.assetspec.FirstOrDefault(assetSpec =>
								assetSpec.assetattrid == assetSpecFromLocal.assetattrid);
							if (assetSpecFromMaximo != null)
							{
								assetSpecFromMaximo.alnvalue = assetSpecFromLocal.alnvalue;
								assetSpecFromMaximo.numvalue = assetSpecFromLocal.numvalue;
							}
						}
					}
					else
					{
						woAssetFinalToBeSaved.assetspec = freshAssetSpecList;
					}

					woAssetFinalToBeSaved = AppContext.maximoService.updateAsset(woAssetFinalToBeSaved);
				}
				else if (woAssetFinalToBeSaved.syncronizationStatus == SyncronizationStatus.MODIFIED)
				{
					woAssetFinalToBeSaved = AppContext.maximoService.updateAsset(woAssetFinalToBeSaved);
				}
			}

			return woAssetFinalToBeSaved;
		}


		private List<MaximoWorkOrder> fetchAllWorkOrdersFromMaximo()
		{
			// WorkOrderSpec and WorkOrderFailureReport come inside WorkOrder
			List<MaximoWorkOrder> maximoWorkOrders = AppContext.maximoService.getWorkOrders(mxuser.userPreferences.selectedPersonGroup);
			/*
			 * for each work order, fetch its details (asset, etc.) 
			 */
			foreach (var maximoWorkOrder in maximoWorkOrders)
			{
				fetchWorkOrderDetailsFromMaximo(maximoWorkOrder);
			}

			return maximoWorkOrders;
		}

		private void fetchWorkOrderDetailsFromMaximo(MaximoWorkOrder maximoWorkOrder)
		{
			// labTrans, toolTrans, workOrderSpec, workOrderFailureReport are coming from getWorkOrders
			AppContext.Log.Debug($"[MX] Calling maximoService.getAsset. wonum: {maximoWorkOrder.wonum}");
			maximoWorkOrder.asset = AppContext.maximoService.getAsset(maximoWorkOrder.assetnum);
			AppContext.Log.Debug($"[MX] Called maximoService.getAsset. wonum: {maximoWorkOrder.wonum}");

			AppContext.Log.Debug($"[MX] Calling maximoService.getWorkOrderDocLinks. wonum: {maximoWorkOrder.wonum}");
			maximoWorkOrder.doclink = AppContext.maximoService.getWorkOrderDocLinks(maximoWorkOrder);
			AppContext.Log.Debug($"[MX] Called maximoService.getWorkOrderDocLinks. wonum: {maximoWorkOrder.wonum}");
		}

		public void clearWorkOrderCompositeFromLocalDb()
		{
			AppContext.workOrderRepository.removeCollection();
			AppContext.assetRepository.removeCollection();
			AppContext.assetSpecRepository.removeCollection();
		}

		// todo: change function name
		public void synchronizeHelperFromMaximoToLocalDb()
		{
			clearHelperFromLocalDb();

			// get domains
			AppContext.domainRepository.upsertList(AppContext.maximoService.getDomains());


			// get failurelist
			// 1283 CatchBasin failurelist id
			List<FailureList> failureLists = new List<FailureList>();
			List<FailureList> tempFailureLists = AppContext.maximoService.getFailureList("1283");
			failureLists.AddRange(tempFailureLists);
			var problemCodes =
				string.Join(",", tempFailureLists.Select(c => c.failurelist.ToString()).ToArray<string>());
			tempFailureLists = AppContext.maximoService.getFailureList(problemCodes);
			failureLists.AddRange(tempFailureLists);
			var causeCodes = string.Join(",", tempFailureLists.Select(c => c.failurelist.ToString()).ToArray<string>());
			tempFailureLists = AppContext.maximoService.getFailureList(causeCodes);
			failureLists.AddRange(tempFailureLists);
			AppContext.failureListRepository.upsertList(failureLists);


			// get inventories
			AppContext.inventoryRepository.upsertList(AppContext.maximoService.getInventory());
		}

		public void clearHelperFromLocalDb()
		{
			AppContext.domainRepository.removeCollection();
			AppContext.failureListRepository.removeCollection();
			AppContext.inventoryRepository.removeCollection();
		}

		public void updateLabors()
		{
			AppContext.laborRepository.removeCollection();
			string[] crafts = new string[] {"SSWR", "SSLR", "SSWL", "SCRW", "CNRW"};

			foreach (string craft in crafts)
			{
				AppContext.laborRepository.upsertList(AppContext.maximoService.getLabors(craft));
			}
		}

		// todo : move to userservice
		public string login(string username, string password)
		{
			// first login to maximo online
			if (AppContext.maximoService.login(username, password))
			{
				try
				{
					MaximoUser mxuserFromMaximo = AppContext.maximoService.whoami();
					mxuser = AppContext.userRepository.findOneIgnoreCase(username);
					if (mxuser == null)
					{
						mxuser = mxuserFromMaximo;
					}
					else
					{
						// merge user data returned from Maximo server to local db entity
						mxuser.mergeFrom(mxuserFromMaximo);
					}


					if (AppContext.laborRepository.Find("person[*].personid", mxuser.personId).Count() == 0)
					{
						updateLabors();
						if (AppContext.laborRepository.Find("person[*].personid", mxuser.personId).Count() == 0)
						{
							return "You don't have laborcraftrate!";
						}
					}


					MaximoPersonGroup maximoPersonGroup = AppContext.maximoService.getPersonGroup(mxuser.personId);

					if (maximoPersonGroup == null)
					{
						return "You don't have crew!";
					}

					if (maximoPersonGroup.persongroupteam != null)
					{
						if (maximoPersonGroup.persongroupteam.Count > 0)
						{
							maximoPersonGroup.leadMan = maximoPersonGroup.persongroupteam[0].respparty;
							maximoPersonGroup.driverMan = maximoPersonGroup.persongroupteam[0].respparty;
						}
						else
						{
							return "Your Crew has 0 person";
						}

						if (maximoPersonGroup.persongroupteam.Count > 1)
						{
							maximoPersonGroup.secondMan = maximoPersonGroup.persongroupteam[1].respparty;
						}
					}
					else
					{
						return "Your Crew has 0 person";
					}

					AppContext.personGroupRepository.removeCollection();
					AppContext.personGroupRepository.insert(maximoPersonGroup);

					mxuser.userPreferences = new UserPreferences();
					mxuser.persongroup = maximoPersonGroup.persongroup;
					mxuser.userPreferences.selectedPersonGroup = mxuser.persongroup;


					mxuser.persongroup = maximoPersonGroup.persongroup;

					if (mxuser.persongroup == null)
					{
						return "You don't have crew!";
					}

					mxuser.password = password;

					AppContext.userRepository.upsert(mxuser);

					return "success";
				}
				catch (Exception e)
				{
					return e.ToString();
				}
			}
			else
			{
				MaximoUser maximoUser = AppContext.userRepository.findOneIgnoreCase(username);
				if (maximoUser.password.Equals(password))
				{
					mxuser = maximoUser;

					return "success";
				}
				else
				{
					return "Password is wrong";
				}
			}
		}
	}
}