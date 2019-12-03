using System;
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
		
		private MaximoService maximoService;

		private UserRepository userRepository;
		private WorkOrderRepository workOrderRepository;
		private AssetRepository assetRepository;
		private AssetSpecRepository assetSpecRepository;
		private DomainRepository domainRepository;
		private AttributeRepository attributeRepository;
		private FailureListRepository failureListRepository;

		public SynchronizationDelegateHandler synchronizationDelegate;
		
		public delegate void SynchronizationDelegateHandler(string status, string substatus);
		
		public SynchronizationService(MaximoService _maximoService,
			UserRepository _userRepository,
			WorkOrderRepository _workOrderRepository,
			AssetRepository _assetRepository,
			AssetSpecRepository _assetSpecRepository,
			DomainRepository _domainRepository,
			AttributeRepository _attributeRepository,
			FailureListRepository _failureListRepository)
		{
			this.maximoService = _maximoService;

			this.userRepository = _userRepository;
			workOrderRepository = _workOrderRepository;
			assetRepository = _assetRepository;
			assetSpecRepository = _assetSpecRepository;
			domainRepository = _domainRepository;
			attributeRepository = _attributeRepository;
			failureListRepository = _failureListRepository;
			
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
		
		public async void synchronizeInBackground()
		{
			synchronizationDelegate("SYNC_STARTED", "started synchronization in background");

			try
			{
				bool isOnline = maximoService.checkIsOnline();
				var lastSyncTime = DateTime.Now;

				if (!isOnline)
				{
					synchronizationDelegate("MAXIMO_OFFLINE", "Maximo service is offline, sleeping...");
					return;
				}

				synchronizationDelegate("SYNC_IN_PROGRESS", "fetching modified work orders from Maximo...");
				
				List<MaximoWorkOrder> maximoWorkOrdersFromMaximo = fetchChangedWorkOrdersFromMaximoSinceLastSyncTime();
				synchronizationDelegate("SYNC_IN_PROGRESS", "fetched " + maximoWorkOrdersFromMaximo.Count + " workorders from Maximo");
				
				// sync the work orders fetched from Maximo to local db
				foreach (var workOrderFromMaximo in maximoWorkOrdersFromMaximo)
				{
					foreach (var maximoWorkOrderSpec in workOrderFromMaximo.workorderspec)
					{
						maximoWorkOrderSpec.syncronizationStatus = SyncronizationStatus.SYNCED;
					}
					foreach (var maximoWorkOrderFailureReport in workOrderFromMaximo.failurereport)
					{
						maximoWorkOrderFailureReport.syncronizationStatus = SyncronizationStatus.SYNCED;
					}
					
					syncEntityFromMaximoToLocalDb<string, MaximoWorkOrder>(workOrderRepository, workOrderFromMaximo,
						workOrderFromMaximo.wonum);

					MaximoAsset maximoAsset = workOrderFromMaximo.asset;
					if(maximoAsset != null)
					{
						foreach (var maximoAssetSpec in maximoAsset.assetspec)
						{
							maximoAssetSpec.syncronizationStatus = SyncronizationStatus.SYNCED;
						}

						syncEntityFromMaximoToLocalDb<string, MaximoAsset>(assetRepository, maximoAsset,
						maximoAsset.assetnum);
					}
					
				}

				IEnumerable<MaximoWorkOrder> workOrdersToBeScyncedFromDb = workOrderRepository.findAllToBeScynced();
				foreach (var workOrderToBeSyncedFromDb in workOrdersToBeScyncedFromDb)
				{
					// TODO - find how to post child entities
					synchronizationDelegate("SYNC_IN_PROGRESS", "Updating work order " + workOrderToBeSyncedFromDb.wonum +  " to Maximo...");
					bool isSuccessfulWorkOrderOperation = maximoService.updateWorkOrder(workOrderToBeSyncedFromDb);

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
						
						workOrderRepository.upsert(workOrderToBeSyncedFromDb);
					}
					else
					{
						synchronizationDelegate("SYNC_IN_PROGRESS", "Failed to update workorder " + workOrderToBeSyncedFromDb.wonum +  " to Maximo...");
						
					}

				}

				IEnumerable<MaximoAsset> assetsToBeScyncedFromDb = assetRepository.findAllToBeScynced();
				foreach (var assetToBeSyncedFromDb in assetsToBeScyncedFromDb)
				{
					synchronizationDelegate("SYNC_IN_PROGRESS", "Updating asset " + assetToBeSyncedFromDb.assetnum +  " to Maximo...");

					bool isSuccessfulAssetOperation = maximoService.updateAsset(assetToBeSyncedFromDb);

					if (isSuccessfulAssetOperation)
					{
						synchronizationDelegate("SYNC_IN_PROGRESS", "Successfully updated asset " + assetToBeSyncedFromDb.assetnum +  " to Maximo...");

						MaximoAsset maximoAssetFreshCopyFromServer = maximoService.getAsset(assetToBeSyncedFromDb.assetnum);
						maximoAssetFreshCopyFromServer.Id = assetToBeSyncedFromDb.Id;
						maximoAssetFreshCopyFromServer.syncronizationStatus = SyncronizationStatus.SYNCED;
						
						foreach (var maximoAssetSpec in maximoAssetFreshCopyFromServer.assetspec)
						{
							maximoAssetSpec.syncronizationStatus = SyncronizationStatus.SYNCED;
						}
						
						assetRepository.upsert(maximoAssetFreshCopyFromServer);
					}
					else
					{
						synchronizationDelegate("SYNC_IN_PROGRESS", "Failed to update asset " + assetToBeSyncedFromDb.assetnum +  " to Maximo...");
						
					}
				}

				maximoService.mxuser.userPreferences.lastSyncTime = lastSyncTime;
				userRepository.upsert(maximoService.mxuser);
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

		private List<MaximoWorkOrder> fetchChangedWorkOrdersFromMaximoSinceLastSyncTime()
		{
			DateTime lastSyncTime = maximoService.mxuser.userPreferences.lastSyncTime;

			List<MaximoWorkOrder> maximoWorkOrders = maximoService.getWorkOrders(lastSyncTime);
			Console.WriteLine($"Fetched {maximoWorkOrders.Count} work orders");

			/*
			 * for each work order, fetch its details (asset, etc.) 
			 */
			foreach (var maximoWorkOrder in maximoWorkOrders)
			{
				MaximoAsset maximoAsset = maximoService.getAsset(maximoWorkOrder.assetnum);
				if (maximoAsset != null)
				{
					if (maximoAsset.assetspec != null)
					{
						List<MaximoAssetSpec> assetSpecs = new List<MaximoAssetSpec>();
						foreach (var assetSpec in maximoAsset.assetspec)
						{
							assetSpec.assetnum = maximoAsset.assetnum;
							assetSpecs.Add(assetSpec);
						}

						maximoAsset.assetspec = assetSpecs;
					}
				}

				maximoWorkOrder.asset = maximoAsset;

				maximoWorkOrder.workorderspec = maximoService.getWorkOrderSpec(maximoWorkOrder.href);
				maximoWorkOrder.failureRemark = maximoService.getWorkOrderFailureRemark(maximoWorkOrder.href);
				maximoWorkOrder.failurereport = maximoService.getWorkOrderFailureReport(maximoWorkOrder.href);
			}

			return maximoWorkOrders;
		}

		public void synchronizeWorkOrderCompositeFromMaximoToLocalDb()
		{
			clearWorkOrderCompositeFromLocalDb();

			List<MaximoWorkOrder> maximoWorkOrders = maximoService.getWorkOrders();
			Console.WriteLine($"Fetched {maximoWorkOrders.Count} work orders");

			/*
			 * for each work order, fetch its details (asset, etc.) 
			 */
			foreach (var maximoWorkOrder in maximoWorkOrders)
			{
				// check if the asset is already in DB
				MaximoAsset maximoAsset = assetRepository.findOne(maximoWorkOrder.assetnum);
				if (maximoAsset == null)
				{
					maximoAsset = maximoService.getAsset(maximoWorkOrder.assetnum);


					if (maximoAsset != null)
					{
						maximoAsset = assetRepository.upsert(maximoAsset);
					}
				}

				maximoWorkOrder.asset = maximoAsset;

				maximoWorkOrder.workorderspec = maximoService.getWorkOrderSpec(maximoWorkOrder.href);
				maximoWorkOrder.failureRemark = maximoService.getWorkOrderFailureRemark(maximoWorkOrder.href);
				maximoWorkOrder.failurereport = maximoService.getWorkOrderFailureReport(maximoWorkOrder.href);
				// synchronize maximoWorkOrder in local db
				MaximoWorkOrder maximoWorkOrderFromDb = workOrderRepository.findOne(maximoWorkOrder.wonum);
				if (maximoWorkOrderFromDb != null)
				{
					maximoWorkOrder.Id = maximoWorkOrderFromDb.Id;
				}

				workOrderRepository.upsert(maximoWorkOrder);
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

			IEnumerable<MaximoAssetSpec> maximoAssetSpecs = assetSpecRepository.findAllUpdated();

			foreach (var assetnum in maximoAssetSpecs.Select(x => x.assetnum).Distinct())
			{
				var asset = assetRepository.findOne(assetnum);
				asset.assetspec = assetSpecRepository.Find("assetnum", assetnum).ToList();
				;

				bool isSuccessful = maximoService.updateAsset(asset);

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
			workOrderRepository.removeCollection();
			assetRepository.removeCollection();
			assetSpecRepository.removeCollection();
		}

		// todo: change function name
		public void synchronizeHelperFromMaximoToLocalDb()
		{
			clearHelperFromLocalDb();
			List<MaximoDomain> domains = maximoService.getDomains();

			foreach (var domain in domains)
			{
				domainRepository.insert(domain);
			}


			List<MaximoAttribute> attributes = maximoService.getAttributes();
			foreach (var attribute in attributes)
			{
				attributeRepository.insert(attribute);
			}

			// 1283 CatchBasin failurelist id
			List<FailureList> failureLists = new List<FailureList>();
			List<FailureList> tempFailureLists = maximoService.getFailureList("1283");
			failureLists.AddRange(tempFailureLists);
			var problemCodes =
				string.Join(",", tempFailureLists.Select(c => c.failurelist.ToString()).ToArray<string>());
			tempFailureLists = maximoService.getFailureList(problemCodes);
			failureLists.AddRange(tempFailureLists);
			var causeCodes = string.Join(",", tempFailureLists.Select(c => c.failurelist.ToString()).ToArray<string>());
			tempFailureLists = maximoService.getFailureList(causeCodes);
			failureLists.AddRange(tempFailureLists);

			foreach (var failureList in failureLists)
			{
				failureListRepository.insert(failureList);
			}
		}

		public void clearHelperFromLocalDb()
		{
			domainRepository.removeCollection();
			assetRepository.removeCollection();
			failureListRepository.removeCollection();
		}
	}
}