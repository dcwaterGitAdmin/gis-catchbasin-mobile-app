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

            maximoService = new MaximoService(dbConnection, userRepository);

            synchronizationService = new SynchronizationService(maximoService,
                workOrderRepository,
                assetRepository,
                assetSpecRepository,
                domainRepository,
                attributeRepository, failureListRepository);
        }
    }
}