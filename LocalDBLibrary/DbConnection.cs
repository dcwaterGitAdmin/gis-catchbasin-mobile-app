using LiteDB;

namespace LocalDBLibrary
{
	public class DbConnection
	{
		private static string dbString = "lite.db";

		public LiteDatabase db { get; }

		public DbConnection()
		{
			// initialize db
			db = new LiteDatabase(@dbString);
		}
	}
}