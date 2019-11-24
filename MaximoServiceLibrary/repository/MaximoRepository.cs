using System;
using LocalDBLibrary;
using MaximoServiceLibrary.model;

namespace MaximoServiceLibrary.repository
{
	public class UserRepository : DbReposistory<String, MaximoUser>
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
	
	public class WorkOrderRepository : DbReposistory<String, MaximoWorkOrder>
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

	public class AssetRepository : DbReposistory<String, MaximoAsset>
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
	
	public class AttributeRepository : DbReposistory<String, MaximoAttribute>
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

	public class DomainRepository : DbReposistory<String, MaximoDomain>
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
	
}