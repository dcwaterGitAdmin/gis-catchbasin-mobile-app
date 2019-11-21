using System.Collections.Generic;
using LiteDB;

namespace LocalDBLibrary
{
	abstract public class DbReposistory<K, T>
	{
		abstract public string tableName();

		private DbConnection dbConnection;

		public DbReposistory(DbConnection _dbConnection)
		{
			this.dbConnection = _dbConnection;
		}

		public void removeCollection()
		{
			dbConnection.db.DropCollection(tableName());
		}

		public long count()
		{
			var collection = dbConnection.db.GetCollection<T>(tableName());
			return collection.Count();
		}
		
		public T findOne(K k)
		{
			var collection = dbConnection.db.GetCollection<T>(tableName());
			return collection.FindOne(Query.EQ("_id", new BsonValue(k)));
		}

		public IEnumerable<T> findAll()
		{
			var collection = dbConnection.db.GetCollection<T>(tableName());
			return collection.FindAll();
		}

		public T upsert(K k, T t)
		{
			var collection = dbConnection.db.GetCollection<T>(tableName());
			collection.Upsert(new BsonValue(k), t);

			return t;
		}
		
		public T insert(K k, T t)
		{
			var collection = dbConnection.db.GetCollection<T>(tableName());
			collection.Insert(new BsonValue(k), t);

			return t;
		}
		
	}
}