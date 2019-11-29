using System;
using LocalDBLibrary;
using MaximoServiceLibrary.model;

namespace MaximoServiceLibrary.repository
{
	public class UserRepository : DbReposistory<string, MaximoUser>
	{
		public UserRepository(DbConnection dbConnection) : base(dbConnection)
		{
		}

		public override string tableName()
		{
			return "users";
		}

		public override string keyField()
		{
			return "userName";
		}
		
	}
	
	public class WorkOrderRepository : DbReposistory<string, MaximoWorkOrder>
	{
		public WorkOrderRepository(DbConnection dbConnection) : base(dbConnection)
		{
		}

		public override string tableName()
		{
			return "workorders";
		}

		public override string keyField()
		{
			return "wonum";
		}
		
	}

	public class AssetRepository : DbReposistory<string, MaximoAsset>
	{
		public AssetRepository(DbConnection dbConnection) : base(dbConnection)
		{
		}

		public override string tableName()
		{
			return "assets";
		}

		public override string keyField()
		{
			return "assetnum";
		}
		
	}
	
	public class AssetSpecRepository : DbReposistory<int, MaximoAssetSpec>
	{
		public AssetSpecRepository(DbConnection dbConnection) : base(dbConnection)
		{
		}

		public override string tableName()
		{
			return "assetSpecs";
		}

		public override string keyField()
		{
			return "Id";
		}

       

    }
	
	public class AttributeRepository : DbReposistory<string, MaximoAttribute>
	{
		public AttributeRepository(DbConnection dbConnection) : base(dbConnection)
		{
		}

		public override string tableName()
		{
			return "attributes";
		}

		public override string keyField()
		{
			return "assetattrid";
		}
		
	}

	public class DomainRepository : DbReposistory<string, MaximoDomain>
	{
		public DomainRepository(DbConnection dbConnection) : base(dbConnection)
		{
		}

		public override string tableName()
		{
			return "domains";
		}

		public override string keyField()
		{
			return "domainid";
		}
		
	}

    public class FailureListRepository : DbReposistory<int, FailureList>
    {
        public FailureListRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public override string tableName()
        {
            return "failurelists";
        }

        public override string keyField()
        {
            return "failurelist";
        }

    }
}