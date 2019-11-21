using System;
using LocalDBLibrary;
using MaximoServiceLibrary.model;

namespace MaximoServiceLibrary.repository
{
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
	
}