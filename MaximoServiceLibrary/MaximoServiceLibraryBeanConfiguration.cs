using LocalDBLibrary;
using log4net;
using MaximoServiceLibrary.repository;
using System.Reflection;

namespace MaximoServiceLibrary
{
    /**
     * dependency injection configuration class
     */
    public static class AppContext
    {
        public static DbConnection dbConnection = new DbConnection();

		public static UserRepository userRepository = new UserRepository(dbConnection);
		public static WorkOrderRepository workOrderRepository = new WorkOrderRepository(dbConnection);
		public static AssetRepository assetRepository = new AssetRepository(dbConnection);
		public static AssetSpecRepository assetSpecRepository = new AssetSpecRepository(dbConnection);
		public static AttributeRepository attributeRepository = new AttributeRepository(dbConnection);
		public static DomainRepository domainRepository = new DomainRepository(dbConnection);
		public static FailureListRepository failureListRepository = new FailureListRepository(dbConnection);
		public static LaborRepository laborRepository = new LaborRepository(dbConnection);
		public static InventoryRepository inventoryRepository = new InventoryRepository(dbConnection);
		public static PersonGroupRepository personGroupRepository = new PersonGroupRepository(dbConnection);

		public static MaximoService maximoService = new MaximoService();

		public static SynchronizationService synchronizationService = new SynchronizationService();

        public static ILog Log
        {
            get
            {
                return log4net.LogManager.GetLogger("CBLOG");
            }
        }
    }
}