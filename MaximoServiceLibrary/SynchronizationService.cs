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
		
		private Timer synchronizationTimer;
		
	
		public SynchronizationDelegateHandler synchronizationDelegate;

		public MaximoUser mxuser;
		
		public delegate void SynchronizationDelegateHandler(string status, string substatus);
		
		public SynchronizationService()
		{
			// every 10 seconds / minutes
			synchronizationTimer = new Timer(10000);
			synchronizationTimer.Elapsed += onSyncTimerElapsed;
			synchronizationTimer.Enabled = false;
			
			synchronizationDelegate = new SynchronizationDelegateHandler(logSynchronizationStatus);

		}

		public void logSynchronizationStatus(string status, string substatus)
		{
			Console.WriteLine($"syncronization status:{status}, substatus:{substatus}");
		}
		
		public void startSyncronizationTimer()
		{
			synchronizationTimer.Enabled = true;
		}

		public void stopSyncronizationTimer()
		{
			synchronizationTimer.Enabled = false;
		}

		public void onSyncTimerElapsed(Object source, ElapsedEventArgs e)
		{
			if (isOffline)
			{
				synchronizationDelegate("SYNC_OFFLINE", "The synchronization is set to be offline, returning");
				return;
			}
			
			Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
			synchronizationTimer.Enabled = false;

			synchronizeInBackground();
		}

		public List<MaximoWorkOrderSpec> generateFreshWorkOrderSpecList(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
		{
			List<MaximoWorkOrderSpec> freshWorkOrderSpecList = new List<MaximoWorkOrderSpec>();
			
			foreach (var woSpecFromMaximo in woFromMaximo.workorderspec)
			{
				MaximoWorkOrderSpec woSpecFromLocal = null;
				if (woFromLocal != null) {
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
						else if (woSpecFromLocal.syncronizationStatus == SyncronizationStatus.MODIFIED)
						{
							woSpecFromLocal.syncronizationStatus = SyncronizationStatus.CONFLICTED;
							freshWorkOrderSpecList.Add(woSpecFromLocal);
						}
						else if (woSpecFromLocal.syncronizationStatus == SyncronizationStatus.CONFLICTED)
						{
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
			
			// if there are still entities in CREATED status in the local copy, add them to fresh list. previously SYNCED entities will be removed
			if (woFromLocal != null)
			{
				foreach (var woSpecFromLocal in woFromLocal.workorderspec)
				{
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

			return freshWorkOrderFailureReportList;
		}
		
		public List<MaximoLabTrans> generateFreshWorkOrderLabTransList(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
		{
			List<MaximoLabTrans> freshWorkOrderLabTransList = new List<MaximoLabTrans>();

			return freshWorkOrderLabTransList;
		}
		
		public List<MaximoToolTrans> generateFreshWorkOrderToolTransList(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
		{
			List<MaximoToolTrans> freshWorkOrderToolTransList = new List<MaximoToolTrans>();

			return freshWorkOrderToolTransList;
		}
		
		public List<MaximoDocLinks> generateFreshWorkOrderDocLinksList(MaximoWorkOrder woFromMaximo, MaximoWorkOrder woFromLocal)
		{
			List<MaximoDocLinks> freshWorkOrderDocLinksList = new List<MaximoDocLinks>();
			return freshWorkOrderDocLinksList;
		}

		public async void synchronizeInBackground()
		{
			synchronizationDelegate("SYNC_STARTED", "started synchronization in background");

			try
			{
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
				// Assuming that when a user changes crew, we will delete all work orders of previous crew
				IEnumerable<MaximoWorkOrder> workOrdersFromLocal = AppContext.workOrderRepository.findAll();
				synchronizationDelegate("SYNC_IN_PROGRESS", "fetched " + workOrdersFromLocal.Count() + " workorders from Local");
				
				// sync the work orders fetched from Maximo to local db
				foreach (var woFromMaximo in workOrdersFromMaximo)
				{
					MaximoWorkOrder woFromLocal = workOrdersFromLocal.FirstOrDefault(wo => wo.wonum == woFromMaximo.wonum);

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
					//List<MaximoWorkOrderFailureReport> freshWorkOrderFailureReports = generateFreshWorkOrderFailureReportList(woFromMaximo, woFromLocal);
					//List<MaximoLabTrans> freshWorkOrderLabTransList = generateFreshWorkOrderLabTransList(woFromMaximo, woFromLocal);
					//List<MaximoToolTrans> freshWorkOrderToolTransList = generateFreshWorkOrderToolTransList(woFromMaximo, woFromLocal);
					//List<MaximoDocLinks> freshWorkOrderDocLinksList = generateFreshWorkOrderDocLinksList(woFromMaximo, woFromLocal);

					woFinalToBeSaved.workorderspec = freshWorkOrderSpecList;

					if (woFromLocal != null && woFromLocal.syncronizationStatus == SyncronizationStatus.COMPLETED)
					{
						woFinalToBeSaved = AppContext.maximoService.updateWorkOrder(woFromLocal);
						
					}

					AppContext.workOrderRepository.upsert(woFinalToBeSaved);
				}

				IEnumerable<MaximoWorkOrder> workOrdersToBeScyncedFromDb = AppContext.workOrderRepository.findAllToBeScynced();
				foreach (var workOrderToBeSyncedFromDb in workOrdersToBeScyncedFromDb)
				{
					// TODO - find how to post child entities
					synchronizationDelegate("SYNC_IN_PROGRESS", "Updating work order " + workOrderToBeSyncedFromDb.wonum +  " to Maximo...");
					bool isSuccessfulWorkOrderOperation = AppContext.maximoService.updateWorkOrder(workOrderToBeSyncedFromDb);

					if (isSuccessfulWorkOrderOperation)
					{
						synchronizationDelegate("SYNC_IN_PROGRESS", "Successfully updated workorder " + workOrderToBeSyncedFromDb.wonum +  " to Maximo...");

						workOrderToBeSyncedFromDb.syncronizationStatus = SyncronizationStatus.SYNCED;
						
						foreach (var maximoWorkOrderSpec in workOrderToBeSyncedFromDb.workorderspec)
						{
							maximoWorkOrderSpec.syncronizationStatus = SyncronizationStatus.SYNCED;
						}
						
						foreach (var maximoWorkOrderFailureReport in workOrderToBeSyncedFromDb.failurereport)
						{
							maximoWorkOrderFailureReport.syncronizationStatus = SyncronizationStatus.SYNCED;
						}

						AppContext.workOrderRepository.upsert(workOrderToBeSyncedFromDb);
					}
					else
					{
						synchronizationDelegate("SYNC_IN_PROGRESS", "Failed to update workorder " + workOrderToBeSyncedFromDb.wonum +  " to Maximo...");
						
					}

				}

				IEnumerable<MaximoAsset> assetsToBeScyncedFromDb = AppContext.assetRepository.findAllToBeScynced();
				foreach (var assetToBeSyncedFromDb in assetsToBeScyncedFromDb)
				{
					synchronizationDelegate("SYNC_IN_PROGRESS", "Updating asset " + assetToBeSyncedFromDb.assetnum +  " to Maximo...");

					bool isSuccessfulAssetOperation = AppContext.maximoService.updateAsset(assetToBeSyncedFromDb);

					if (isSuccessfulAssetOperation)
					{
						synchronizationDelegate("SYNC_IN_PROGRESS", "Successfully updated asset " + assetToBeSyncedFromDb.assetnum +  " to Maximo...");

						MaximoAsset maximoAssetFreshCopyFromServer = AppContext.maximoService.getAsset(assetToBeSyncedFromDb.assetnum);
						maximoAssetFreshCopyFromServer.Id = assetToBeSyncedFromDb.Id;
						maximoAssetFreshCopyFromServer.syncronizationStatus = SyncronizationStatus.SYNCED;
						
						foreach (var maximoAssetSpec in maximoAssetFreshCopyFromServer.assetspec)
						{
							maximoAssetSpec.syncronizationStatus = SyncronizationStatus.SYNCED;
						}

						AppContext.assetRepository.upsert(maximoAssetFreshCopyFromServer);
					}
					else
					{
						synchronizationDelegate("SYNC_IN_PROGRESS", "Failed to update asset " + assetToBeSyncedFromDb.assetnum +  " to Maximo...");
						
					}
				}

				mxuser.userPreferences.lastSyncTime = lastSyncTime;
				AppContext.userRepository.upsert(mxuser);
			}
			finally
			{
				synchronizationDelegate("SYNC_FINISHED", null);
				
				synchronizationTimer.Enabled = true;
			}
		}

		private T syncEntityFromMaximoToLocalDb<K, T>(DbReposistory<K, T> dbRepository, T entityFromMaximo,
			K entityKeyValue) where T : BasePersistenceEntity
		{
			T entityFromDb = dbRepository.findOne(entityKeyValue);
			if (entityFromDb == null)
			{
				Console.WriteLine($"inserting entity [{typeof(T)}: {entityKeyValue}] fetched from Maximo to local db");
				entityFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
				dbRepository.insert(entityFromMaximo);
			}
			else
			{
				if (entityFromDb.syncronizationStatus == null ||
				    entityFromDb.syncronizationStatus == SyncronizationStatus.SYNCED)
				{
					Console.WriteLine($"upserting entity [{typeof(T)}: {entityKeyValue}] fetched from Maximo to local db");
					entityFromMaximo.Id = entityFromDb.Id;
					entityFromMaximo.syncronizationStatus = SyncronizationStatus.SYNCED;
					dbRepository.upsert(entityFromMaximo);
				}
				else
				{
					Console.WriteLine(
						$"sync CONFLICT at entity [{typeof(T)}: {entityKeyValue}] fetched from Maximo to local db");
					// this is a conflicting scenario, what should we do here? 
					// TODO - decide what to do here

					entityFromDb.syncronizationStatus = SyncronizationStatus.CONFLICTED;
					dbRepository.upsert(entityFromDb);
				}
			}

			return entityFromMaximo;
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
				maximoWorkOrder.asset = AppContext.maximoService.getAsset(maximoWorkOrder.assetnum);
				maximoWorkOrder.labtrans = AppContext.maximoService.getWorkOrderLabTrans(maximoWorkOrder);
				// TODO not implemented yet
				//maximoWorkOrder.tooltrans = AppContext.maximoService.getWorkOrderToolTrans(maximoWorkOrder);
				//maximoWorkOrder.docs = AppContext.maximoService.getWorkOrderDockLinks(maximoWorkOrder);
			}

			return maximoWorkOrders;
		}

		public void synchronizeWorkOrderCompositeFromMaximoToLocalDb()
		{
			clearWorkOrderCompositeFromLocalDb();

			List<MaximoWorkOrder> maximoWorkOrders = AppContext.maximoService.getWorkOrders(mxuser.userPreferences.selectedPersonGroup);
			Console.WriteLine($"Fetched {maximoWorkOrders.Count} work orders");

			/*
			 * for each work order, fetch its details (asset, etc.) 
			 */
			foreach (var maximoWorkOrder in maximoWorkOrders)
			{
				// check if the asset is already in DB
				MaximoAsset maximoAsset = AppContext.assetRepository.findOne(maximoWorkOrder.assetnum);
				if (maximoAsset == null)
				{
					maximoAsset = AppContext.maximoService.getAsset(maximoWorkOrder.assetnum);


					if (maximoAsset != null)
					{
						maximoAsset = AppContext.assetRepository.upsert(maximoAsset);
					}
				}

				maximoWorkOrder.asset = maximoAsset;

				maximoWorkOrder.workorderspec = AppContext.maximoService.getWorkOrderSpec(maximoWorkOrder);
				//maximoWorkOrder.failureRemark = AppContext.maximoService.getWorkOrderFailureRemark(maximoWorkOrder.href);
				maximoWorkOrder.failurereport = AppContext.maximoService.getWorkOrderFailureReport(maximoWorkOrder);
				// synchronize maximoWorkOrder in local db
				MaximoWorkOrder maximoWorkOrderFromDb = AppContext.workOrderRepository.findOne(maximoWorkOrder.wonum);
				if (maximoWorkOrderFromDb != null)
				{
					maximoWorkOrder.Id = maximoWorkOrderFromDb.Id;
				}

				AppContext.workOrderRepository.upsert(maximoWorkOrder);
			}
		}

		public async void synchronizeWorkOrderCompositeFromLocalDbToMaximo()
		{
			// todo:this is next step
//			IEnumerable<MaximoWorkOrder> maximoWorkOrders = workOrderRepository.findAllUpdated();
//			foreach (var maximoWorkOrder in maximoWorkOrders)
//			{
//				Console.WriteLine($"synchronizing workorder : [{maximoWorkOrder.wonum}] to Maximo");
//
//				bool isSuccessful = maximoService.updateWorkOrder(maximoWorkOrder);
//
//				if (isSuccessful)
//				{
//					maximoWorkOrder.editedFromApp = false;
//					workOrderRepository.upsert(maximoWorkOrder);
//				}
//			}

			IEnumerable<MaximoAssetSpec> maximoAssetSpecs = AppContext.assetSpecRepository.findAllUpdated();

			foreach (var assetnum in maximoAssetSpecs.Select(x => x.assetnum).Distinct())
			{
				var asset = AppContext.assetRepository.findOne(assetnum);
				asset.assetspec = AppContext.assetSpecRepository.Find("assetnum", assetnum).ToList();
				;

				bool isSuccessful = AppContext.maximoService.updateAsset(asset);

				if (isSuccessful)
				{
					// todo review
					//maximoAssetSpec.editedFromApp = false;
					//assetSpecRepository.upsert(maximoAssetSpec);
				}
			}
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
			//AppContext.domainRepository.upsertList(AppContext.maximoService.getDomains());


			// get attributes

			//AppContext.attributeRepository.upsertList(AppContext.maximoService.getAttributes());
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
			//AppContext.inventoryRepository.upsertList(AppContext.maximoService.getInventory());


			//List<MaximoPersonGroup> maximoPersonGroups = AppContext.maximoService.getPersonGroups();

			//for (int i = 0; i < maximoPersonGroups.Count; i++)
			//{
			//	if (maximoPersonGroups[i].persongroupteam != null)
			//	{
			//		if (maximoPersonGroups[i].persongroupteam.Count > 0)
			//		{
			//			maximoPersonGroups[i].leadMan = maximoPersonGroups[i].persongroupteam[0].respparty;
			//			maximoPersonGroups[i].driverMan = maximoPersonGroups[i].persongroupteam[0].respparty;

			//		}
			//		if (maximoPersonGroups[i].persongroupteam.Count > 1)
			//		{
			//			maximoPersonGroups[i].secondMan = maximoPersonGroups[i].persongroupteam[1].respparty;
			//		}
					
			//	}
			//}
			
			//AppContext.personGroupRepository.upsertList(maximoPersonGroups);


			


		}

		public void clearHelperFromLocalDb()
		{
			//AppContext.domainRepository.removeCollection();
			//AppContext.assetRepository.removeCollection();
			AppContext.failureListRepository.removeCollection();
			//
			//AppContext.inventoryRepository.removeCollection();
			//AppContext.personGroupRepository.removeCollection();
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
		public bool login(string username, string password)
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
						{ return false;
						}
							
					}


					MaximoPersonGroup maximoPersonGroup = AppContext.maximoService.getPersonGroup(mxuser.personId);

					if (maximoPersonGroup == null)
					{
						return false;
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
							return false;
						}
						if (maximoPersonGroup.persongroupteam.Count > 1)
						{
							maximoPersonGroup.secondMan = maximoPersonGroup.persongroupteam[1].respparty;
						}

					}
					else
					{
						return false;
					}

					AppContext.personGroupRepository.removeCollection();
					AppContext.personGroupRepository.insert(maximoPersonGroup);

					mxuser.userPreferences = new UserPreferences();
					mxuser.persongroup = maximoPersonGroup.persongroup;
					mxuser.userPreferences.selectedPersonGroup = mxuser.persongroup;


					mxuser.persongroup = maximoPersonGroup.persongroup;

					if (mxuser.persongroup == null)
					{
						return false;
					}

					mxuser.password = password;

					AppContext.userRepository.upsert(mxuser);

					return true;
				}catch(Exception e)
				{
					return false;
				}
				
			}
			else
			{
				MaximoUser maximoUser = AppContext.userRepository.findOneIgnoreCase(username);
				if (maximoUser.password.Equals(password))
				{
					mxuser = maximoUser;
					mxuser.userPreferences.selectedPersonGroup = "CB06";
					mxuser.persongroup = "CB06";
					AppContext.userRepository.upsert(mxuser);

					return true;
				}
				else
				{
					return false;
				}
			}
		}

	}
}