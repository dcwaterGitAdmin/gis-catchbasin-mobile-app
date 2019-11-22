using System;
using System.Collections.Generic;
using LocalDBLibrary;
using MaximoServiceLibrary.model;
using MaximoServiceLibrary.repository;

namespace MaximoServiceLibrary
{
	public class SynchronizationService
	{
		private MaximoService maximoService;
		private DbConnection dbConnection;

		public WorkOrderRepository workOrderRepository { get; }
		public AssetRepository assetRepository { get; }
		public AssetSpecRepository assetSpecRepository { get; }
		public DomainRepository domainRepository { get; }
		public AttributeRepository attributeRepository { get; }
		
		public SynchronizationService(MaximoService _maximoService, DbConnection _dbConnection)
		{
			this.maximoService = _maximoService;
			this.dbConnection = _dbConnection;
			
			workOrderRepository = new WorkOrderRepository(dbConnection);
			assetRepository = new AssetRepository(dbConnection);
			assetSpecRepository = new AssetSpecRepository(dbConnection);
			domainRepository = new DomainRepository(dbConnection);
			attributeRepository = new AttributeRepository(dbConnection);
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
	                    if (maximoAsset.assetspec != null)
	                    {
		                    List<MaximoAssetSpec> assetSpecs = new List<MaximoAssetSpec>();
		                    foreach (var assetSpec in maximoAsset.assetspec)
		                    {
			                    assetSpecs.Add(assetSpecRepository.upsert(assetSpec)));
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

		public void synchronizeWorkOrderCompositeFromLocalDbToMaximo()
		{
			IEnumerable<MaximoWorkOrder> maximoWorkOrders = workOrderRepository.findAllUpdated();
			foreach (var maximoWorkOrder in maximoWorkOrders)
			{
				Console.WriteLine($"synchronizing workorder : [{maximoWorkOrder.wonum}] to Maximo");

				bool isSuccessful = maximoService.updateWorkOrder(maximoWorkOrder);

				if (isSuccessful)
				{
					maximoWorkOrder.editedFromApp = false;
					workOrderRepository.upsert(maximoWorkOrder);
				}
			}
			
			
		}


        public void clearWorkOrderCompositeFromLocalDb()
        {
            workOrderRepository.removeCollection();
            assetRepository.removeCollection();
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