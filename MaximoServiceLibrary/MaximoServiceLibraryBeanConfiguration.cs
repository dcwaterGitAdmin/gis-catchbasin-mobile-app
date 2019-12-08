using LocalDBLibrary;
using MaximoServiceLibrary.repository;

namespace MaximoServiceLibrary
{
    /**
     * dependency injection configuration class
     */
    public class MaximoServiceLibraryBeanConfiguration
    {
        public DbConnection dbConnection { get; }
        
        public UserRepository userRepository { get; }
        public WorkOrderRepository workOrderRepository { get; }
        public AssetRepository assetRepository { get; }
        public AssetSpecRepository assetSpecRepository { get; }
        public AttributeRepository attributeRepository { get; }
        public DomainRepository domainRepository { get; }
        public FailureListRepository failureListRepository { get; }
		public LaborRepository laborRepository { get; }
		public InventoryRepository inventoryRepository { get; }

        public MaximoService maximoService { get; }
        
        public SynchronizationService synchronizationService { get; }

        public MaximoServiceLibraryBeanConfiguration()
        {
            dbConnection = new DbConnection();

            userRepository = new UserRepository(dbConnection);
            workOrderRepository = new WorkOrderRepository(dbConnection);
            assetRepository = new AssetRepository(dbConnection);
            assetSpecRepository = new AssetSpecRepository(dbConnection);
            attributeRepository = new AttributeRepository(dbConnection);
            domainRepository = new DomainRepository(dbConnection);
            failureListRepository = new FailureListRepository(dbConnection);
			laborRepository = new LaborRepository(dbConnection);
			inventoryRepository = new InventoryRepository(dbConnection);
            maximoService = new MaximoService(dbConnection, userRepository);

            synchronizationService = new SynchronizationService(maximoService,
                userRepository,
                workOrderRepository,
                assetRepository,
                assetSpecRepository,
                domainRepository,
                attributeRepository, failureListRepository, laborRepository, inventoryRepository);
        }
    }
}