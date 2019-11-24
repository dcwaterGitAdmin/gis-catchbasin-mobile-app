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
		
		public SynchronizationService(MaximoService _maximoService, 
			WorkOrderRepository _workOrderRepository,
			AssetRepository _assetRepository,
			AssetSpecRepository _assetSpecRepository,
			DomainRepository _domainRepository,
			AttributeRepository _attributeRepository)
		{
			this.maximoService = _maximoService;
			
			workOrderRepository = _workOrderRepository;
			assetRepository = _assetRepository;
			assetSpecRepository = _assetSpecRepository;
			domainRepository = _domainRepository;
			attributeRepository = _attributeRepository;
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
	                    if (maximoAsset.assetspec != null)
	                    {
		                    List<MaximoAssetSpec> assetSpecs = new List<MaximoAssetSpec>();
		                    foreach (var assetSpec in maximoAsset.assetspec)
		                    {
                                assetSpec.assetnum = maximoAsset.assetnum;
			                    assetSpecs.Add(assetSpecRepository.insert(assetSpec));
		                    }

		                    maximoAsset.assetspec = assetSpecs;
	                    }
	                    
	                    
                        maximoAsset = assetRepository.upsert(maximoAsset);
                    }


                }

                maximoWorkOrder.asset = maximoAsset;
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
                asset.assetspec = assetSpecRepository.Find("assetnum", assetnum).ToList(); ;

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
			
		}

        public void clearHelperFromLocalDb()
        {
            domainRepository.removeCollection();
            assetRepository.removeCollection();
        }
    }
}