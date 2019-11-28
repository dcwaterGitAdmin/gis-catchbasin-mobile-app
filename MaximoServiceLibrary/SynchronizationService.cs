using System;
using System.Collections.Generic;
using System.Linq;
using LocalDBLibrary;
using MaximoServiceLibrary.model;
using MaximoServiceLibrary.repository;

namespace MaximoServiceLibrary
{
	public class SynchronizationService
	{
		private MaximoService maximoService;

		private WorkOrderRepository workOrderRepository;
		private AssetRepository assetRepository;
		private AssetSpecRepository assetSpecRepository;
		private DomainRepository domainRepository;
		private AttributeRepository attributeRepository;
        private FailureListRepository failureListRepository;
        
        public SynchronizationService(MaximoService _maximoService, 
			WorkOrderRepository _workOrderRepository,
			AssetRepository _assetRepository,
			AssetSpecRepository _assetSpecRepository,
			DomainRepository _domainRepository,
			AttributeRepository _attributeRepository,
            FailureListRepository _failureListRepository)
		{
			this.maximoService = _maximoService;
			
			workOrderRepository = _workOrderRepository;
			assetRepository = _assetRepository;
			assetSpecRepository = _assetSpecRepository;
			domainRepository = _domainRepository;
			attributeRepository = _attributeRepository;
            failureListRepository = _failureListRepository;
        }

        public async void synchronizeInBackground()
        {
	        bool isOnline = maximoService.checkIsOnline();

	        if (!isOnline)
		        return;

	        List<MaximoWorkOrder> maximoWorkOrdersFromMaximo = fetchChangedWorkOrdersFromMaximoSinceLastSyncTime();

        }

        private List<MaximoWorkOrder> fetchChangedWorkOrdersFromMaximoSinceLastSyncTime()
        {
	        DateTime lastSyncTime = maximoService.mxuser.userPreferences.lastSyncTime;
	        
            List<MaximoWorkOrder> maximoWorkOrders = maximoService.getWorkOrders();
			Console.WriteLine($"Fetched {maximoWorkOrders.Count} work orders");
			
			/*
			 * for each work order, fetch its details (asset, etc.) 
			 */
			foreach (var maximoWorkOrder in maximoWorkOrders)
			{

				MaximoAsset maximoAsset = maximoService.getAsset(maximoWorkOrder.assetnum);
                if (maximoAsset != null)
                {
                    if (maximoAsset.assetspecList != null)
                    {
	                    List<MaximoAssetSpec> assetSpecs = new List<MaximoAssetSpec>();
	                    foreach (var assetSpec in maximoAsset.assetspecList)
	                    {
                            assetSpec.assetnum = maximoAsset.assetnum;
		                    assetSpecs.Add(assetSpec);

	                    }

	                    maximoAsset.assetspecList = assetSpecs;
                    }
                }

                maximoWorkOrder.asset = maximoAsset;
                
                maximoWorkOrder.workorderspecList = maximoService.getWorkOrderSpec(maximoWorkOrder.href); 
                maximoWorkOrder.failureRemark = maximoService.getWorkOrderFailureRemark(maximoWorkOrder.href);
                maximoWorkOrder.failureReportList = maximoService.getWorkOrderFailureReport(maximoWorkOrder.href);
			}

			return maximoWorkOrders;
        }
        
		public async void synchronizeWorkOrderCompositeFromMaximoToLocalDb()
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
	                    if (maximoAsset.assetspecList != null)
	                    {
		                    List<MaximoAssetSpec> assetSpecs = new List<MaximoAssetSpec>();
		                    foreach (var assetSpec in maximoAsset.assetspecList)
		                    {
                                assetSpec.assetnum = maximoAsset.assetnum;
			                    assetSpecs.Add(assetSpecRepository.insert(assetSpec));

		                    }

		                    maximoAsset.assetspecList = assetSpecs;
	                    }
	                    
	                    
                        maximoAsset = assetRepository.upsert(maximoAsset);
                    }


                }

                maximoWorkOrder.asset = maximoAsset;
              
                maximoWorkOrder.workorderspecList = maximoService.getWorkOrderSpec(maximoWorkOrder.href); 
                maximoWorkOrder.failureRemark = maximoService.getWorkOrderFailureRemark(maximoWorkOrder.href);
                maximoWorkOrder.failureReportList = maximoService.getWorkOrderFailureReport(maximoWorkOrder.href);
                // synchronize maximoWorkOrder in local db
                MaximoWorkOrder maximoWorkOrderFromDb = workOrderRepository.findOne(maximoWorkOrder.wonum);
				if (maximoWorkOrderFromDb != null)
				{
					maximoWorkOrder.Id = maximoWorkOrderFromDb.Id;
				}

				workOrderRepository.upsert(maximoWorkOrder);
				
				
			}
			
			
		}

        public async void  synchronizeWorkOrderCompositeFromLocalDbToMaximo()
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
                asset.assetspecList = assetSpecRepository.Find("assetnum", assetnum).ToList(); ;

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

   //         clearHelperFromLocalDb();
			//List<MaximoDomain> domains = maximoService.getDomains();

			//foreach (var domain in domains)
			//{
			//	domainRepository.insert(domain);
			//}
			
			
			//List<MaximoAttribute> attributes = maximoService.getAttributes();
			//foreach (var attribute in attributes)
			//{
			//	attributeRepository.insert(attribute);
			//}

            // 1283 CatchBasin failurelist id
            List<FailureList> failureLists = new List<FailureList>();
            List<FailureList> tempFailureLists = maximoService.getFailureList("1283");
            failureLists.AddRange(tempFailureLists);
            var problemCodes = string.Join(",", tempFailureLists.Select(c => c.failurelist.ToString()).ToArray<string>());
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
        }
    }
}