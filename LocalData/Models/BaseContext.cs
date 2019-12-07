using System.Data.Entity;

namespace DCWaterMobile.LocalData.Models
{
    public class BaseContext<TContext>
      : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }
        protected BaseContext()
            : base("Name=MxLocalCacheDatabase")
        { }
    }
}