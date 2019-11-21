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
		public DomainRepository domainRepository { get; }
		public AttributeRepository attributeRepository { get; }
		
		public SynchronizationService(MaximoService _maximoService, DbConnection _dbConnection)
		{
			this.maximoService = _maximoService;
			this.dbConnection = _dbConnection;
			
			workOrderRepository = new WorkOrderRepository(dbConnection);
			assetRepository = new AssetRepository(dbConnection);
			
			domainRepository = new DomainRepository(dbConnection);
			attributeRepository = new AttributeRepository(dbConnection);
		}

		public void synchronizeWorkOrderCompositeFromMaximoToLocalDb()
		{
			List<MaximoWorkOrder> maximoWorkOrders = maximoService.getWorkOrders();
			Console.WriteLine($"Fetched {maximoWorkOrders.Count} work orders");
			
			/*
			 * for each work order, fetch its details (asset, etc.) 
			 */
			foreach (var maximoWorkOrder in maximoWorkOrders)
			{
				// synchronize maximoWorkOrder in local db
				MaximoWorkOrder maximoWorkOrderFromDb = workOrderRepository.findOne(maximoWorkOrder.wonum);
				if (maximoWorkOrderFromDb != null)
				{
					maximoWorkOrder.Id = maximoWorkOrderFromDb.Id;
				}

				workOrderRepository.upsert(maximoWorkOrder);
				
				// check if the asset is already in DB
				MaximoAsset maximoAsset = assetRepository.findOne(maximoWorkOrder.assetnum);
				if (maximoAsset == null)
				{
					maximoAsset = maximoService.getAsset(maximoWorkOrder.assetnum);
					maximoAsset = assetRepository.upsert(maximoAsset);
				}
				
				maximoWorkOrder.asset = maximoAsset;
			}
			
			
		}


		// todo: change function name
		public void synchronizeHelperFromMaximoToLocalDb()
		{
			
			domainRepository.removeCollection();
			List<MaximoDomain> domains = maximoService.getDomains();

			foreach (var domain in domains)
			{
				domainRepository.insert(domain);
			}
			
			attributeRepository.removeCollection();
			List<MaximoAttribute> attributes = maximoService.getAttributes();
			foreach (var attribute in attributes)
			{
				attributeRepository.insert(attribute);
			}
			
		}
	}
}