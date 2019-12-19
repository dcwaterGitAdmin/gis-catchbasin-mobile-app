using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using LocalDBLibrary;
using LocalDBLibrary.model;
using MaximoServiceLibrary.model;
using MaximoServiceLibrary.repository;

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
			AppContext.Log.Warn($"syncronization status:{status}, substatus:{substatus}");
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

			synchronizeInBackground();
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
				synchronizationDelegate("SYNC_IN_PROGRESS", "fetched " + workOrdersFromMaximo.Count + " workorders from Maximo");

				synchronizationDelegate("SYNC_IN_PROGRESS", "fetching all work orders from Local...");
				// TODO Assuming that when a user changes crew, we will delete all work orders of previous crew
				IEnumerable<MaximoWorkOrder> workOrdersFromLocal = AppContext.workOrderRepository.findAll();
				synchronizationDelegate("SYNC_IN_PROGRESS", "fetched " + workOrdersFromLocal.Count() + " workorders from Local");

				// sync the work orders
				foreach (var woFromMaximo in workOrdersFromMaximo)
				{
					try
					{
						MaximoWorkOrder woFromLocal = workOrdersFromLocal.FirstOrDefault(wo => wo.wonum == woFromMaximo.wonum);

						synchronizeWorkOrder(woFromMaximo, woFromLocal);
					}
					catch (Exception ex)
					{
						AppContext.Log.Error(ex.StackTrace);
					}
				}
				
				// POST CREATED work orders to Maximo
				workOrdersFromLocal = AppContext.workOrderRepository.findAll();
				foreach (var woFromLocal in workOrdersFromLocal)
				{
					try
					{
						if (woFromLocal.completed && woFromLocal.syncronizationStatus == SyncronizationStatus.CREATED)
						{
							postWorkOrderToMaximo(woFromLocal, woFromLocal.workorderspec, woFromLocal.failurereport, woFromLocal.labtrans, woFromLocal.tooltrans);
						}
					}
					catch (Exception ex)
					{
						AppContext.Log.Error(ex.StackTrace);
					}
				}
				

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
			MaximoWorkOrder woFinalToBeSaved = woFromMaximo;
			// There exists a Local copy for WorkOrder
			if (woFromLocal != null)
			{
				//means item is changed in maximo side
				if (woFromMaximo._rowstamp != woFromLocal._rowstamp)
				{
					if (woFromLocal.syncronizationStatus == SyncronizationStatus.SYNCED)
					{
						woFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
						woFromMaximo.Id = woFromLocal.Id;
						//insert into local with all childs
					}
					else if (woFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED ||
					         woFromLocal.syncronizationStatus == SyncronizationStatus.CONFLICTED)
					{
						woFromLocal.syncronizationStatus = SyncronizationStatus.CONFLICTED;
						woFinalToBeSaved = woFromLocal;
					}
				}
				//means item is not changed in maximo side
				else
				{
					woFinalToBeSaved = woFromLocal;
				}
			}
			// There is no Local copy for WorkOrder
			else
			{
				// Insert WorkOrder as SYNCED
				woFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
			}

			List<MaximoWorkOrderSpec> freshWorkOrderSpecList = generateFreshWorkOrderSpecList(woFromMaximo, woFromLocal);
			List<MaximoWorkOrderFailureReport> freshWorkOrderFailureReportList =
				generateFreshWorkOrderFailureReportList(woFromMaximo, woFromLocal);
			List<MaximoLabTrans> freshWorkOrderLabTransList = generateFreshWorkOrderLabTransList(woFromMaximo, woFromLocal);
			List<MaximoToolTrans> freshWorkOrderToolTransList = generateFreshWorkOrderToolTransList(woFromMaximo, woFromLocal);
			//List<MaximoDocLinks> freshWorkOrderDocLinksList = generateFreshWorkOrderDocLinksList(woFromMaximo, woFromLocal);

			woFinalToBeSaved.workorderspec = freshWorkOrderSpecList;
			woFinalToBeSaved.failurereport = freshWorkOrderFailureReportList;
			woFinalToBeSaved.labtrans = freshWorkOrderLabTransList;
			woFinalToBeSaved.tooltrans = freshWorkOrderToolTransList;
			//woFinalToBeSaved.doclink = freshWorkOrderDocLinksList;

			// SYNCH ASSET
			MaximoAsset woAssetFinalToBeSaved = synchAsset(woFromMaximo, woFromLocal);
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

			woFinalToBeSaved.asset = woAssetFinalToBeSaved;

			if (woFinalToBeSaved.completed)
			{
				woFinalToBeSaved = postWorkOrderToMaximo(woFinalToBeSaved, freshWorkOrderSpecList, freshWorkOrderFailureReportList, freshWorkOrderLabTransList, freshWorkOrderToolTransList);
			}
			

			AppContext.workOrderRepository.upsert(woFinalToBeSaved);
		}

		private MaximoWorkOrder postWorkOrderToMaximo(MaximoWorkOrder woFinalToBeSaved, List<MaximoWorkOrderSpec> freshWorkOrderSpecList,
			List<MaximoWorkOrderFailureReport> freshWorkOrderFailureReportList, List<MaximoLabTrans> freshWorkOrderLabTransList, List<MaximoToolTrans> freshWorkOrderToolTransList)
		{
			MaximoWorkOrder woFromLocal = woFinalToBeSaved;
			
			if (woFinalToBeSaved != null && woFinalToBeSaved.completed)
			{
				if (woFinalToBeSaved.syncronizationStatus == SyncronizationStatus.CREATED)
				{
					// in the first create call to Maximo, we have to clear the related entities
					woFinalToBeSaved.workorderspec = null;
					woFinalToBeSaved.failurereport = null;
					woFinalToBeSaved.labtrans = null;
					woFinalToBeSaved.tooltrans = null;
					woFinalToBeSaved.doclink = null;

					woFinalToBeSaved = AppContext.maximoService.createWorkOrder(woFinalToBeSaved);

					// in the second  call to Maximo, we have to put the related entities in the request
					// merge workorderspec values to workorder fetched from Maximo after creation
					if (woFinalToBeSaved.workorderspec != null)
					{
						foreach (var workOrderSpecFromLocal in freshWorkOrderSpecList)
						{
							var workorderSpecFromMaximo = woFinalToBeSaved.workorderspec.FirstOrDefault(workorderSpec =>
								workorderSpec.assetattrid == workOrderSpecFromLocal.assetattrid);
							if (workorderSpecFromMaximo != null)
							{
								workorderSpecFromMaximo.alnvalue = workOrderSpecFromLocal.alnvalue;
								workorderSpecFromMaximo.numvalue = workOrderSpecFromLocal.numvalue;
							}
						}
					}
					else
					{
						woFinalToBeSaved.workorderspec = freshWorkOrderSpecList;
					}

					woFinalToBeSaved.failurereport = freshWorkOrderFailureReportList;

					woFinalToBeSaved = AppContext.maximoService.updateWorkOrder(woFinalToBeSaved);

					woFinalToBeSaved.labtrans = freshWorkOrderLabTransList;
					woFinalToBeSaved.tooltrans = freshWorkOrderToolTransList;
					//woFinalToBeSaved.doclink = freshWorkOrderDocLinksList;

					woFinalToBeSaved = AppContext.maximoService.updateWorkOrderActuals(woFinalToBeSaved);
				}
				else if (woFinalToBeSaved.syncronizationStatus == SyncronizationStatus.MODIFIED)
				{
					woFinalToBeSaved = AppContext.maximoService.updateWorkOrder(woFinalToBeSaved);

					woFinalToBeSaved = AppContext.maximoService.updateWorkOrderActuals(woFromLocal);
				}

				//post follow up work orders
				foreach (var followupWorkOrder in woFromLocal.followups)
				{
					followupWorkOrder.origrecordid = woFinalToBeSaved.wonum;
					AppContext.maximoService.createWorkOrder(followupWorkOrder);
				}

				fetchWorkOrderDetailsFromMaximo(woFinalToBeSaved);
			}

			return woFinalToBeSaved;
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
						woSpecFromLocal = woFromLocal.workorderspec.Find(wospec =>
							wospec.workorderspecid == woSpecFromMaximo.workorderspecid);
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

		public List<MaximoWorkOrderFailureReport> generateFreshWorkOrderFailureReportList(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
		{
			List<MaximoWorkOrderFailureReport> freshWorkOrderFailureReportList = new List<MaximoWorkOrderFailureReport>();

			if (woFromMaximo.failurereport != null)
			{
				foreach (var woFailureReportFromMaximo in woFromMaximo.failurereport)
				{
					MaximoWorkOrderFailureReport woFailureReportFromLocal = null;
					if (woFromLocal != null)
					{
						woFailureReportFromLocal = woFromLocal.failurereport.Find(wosfr => wosfr.failurereportid == woFailureReportFromMaximo.failurereportid);
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
		
		public List<MaximoLabTrans> generateFreshWorkOrderLabTransList(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
		{
			List<MaximoLabTrans> freshWorkOrderLabTransList = new List<MaximoLabTrans>();
			
			if (woFromMaximo.labtrans != null)
			{
				foreach (var woLabTransFromMaximo in woFromMaximo.labtrans)
				{
					MaximoLabTrans woLabTransFromLocal = null;
					if (woFromLocal != null)
					{
						woLabTransFromLocal = woFromLocal.labtrans.Find(woslt => woslt.labtransid == woLabTransFromMaximo.labtransid);
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
		
		public List<MaximoToolTrans> generateFreshWorkOrderToolTransList(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
		{
			
			List<MaximoToolTrans> freshWorkOrderToolTransList = new List<MaximoToolTrans>();
			
			if (woFromMaximo.tooltrans != null)
			{
				foreach (var woToolTransFromMaximo in woFromMaximo.tooltrans)
				{
					MaximoToolTrans woToolTransFromLocal = null;
					if (woFromLocal != null)
					{
						woToolTransFromLocal = woFromLocal.tooltrans.Find(wostt => wostt.tooltransid == woToolTransFromMaximo.tooltransid);
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
		
		public List<MaximoDocLinks> generateFreshWorkOrderDocLinksList(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
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

		public List<MaximoAssetSpec> generateFreshAssetSpecList(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
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
						woAssetSpecFromLocal = woFromLocal.asset.assetspec.Find(woas => woas.assetspecid == woAssetSpecFromMaximo.assetspecid);
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
				maximoWorkOrder.asset = AppContext.maximoService.getAsset(maximoWorkOrder.assetnum);
				maximoWorkOrder.doclink = AppContext.maximoService.getWorkOrderDocLinks(maximoWorkOrder);
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


			// get attributes

			AppContext.attributeRepository.upsertList(AppContext.maximoService.getAttributes());
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



			// get labors
			



			// get inventories
			AppContext.inventoryRepository.upsertList(AppContext.maximoService.getInventory());

		}

		public void clearHelperFromLocalDb()
		{
			AppContext.domainRepository.removeCollection();
			AppContext.assetRepository.removeCollection();
			AppContext.failureListRepository.removeCollection();
			AppContext.inventoryRepository.removeCollection();
			
		}

		public void updateLabors()
		{
			AppContext.laborRepository.removeCollection();
			string[] crafts = new string[] { "SSWR", "SSLR", "SSWL", "SCRW", "CNRW" };

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
				}catch(Exception e)
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