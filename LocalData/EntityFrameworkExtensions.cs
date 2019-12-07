using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace DCWaterMobile.LocalData
{
    public static class EntityFrameworkExtensions
    {
        public static bool IsAttachedTo(this ObjectContext context, object entity)
        {
            ObjectStateEntry entry;
            string setName = ((EntityObject)entity).EntityKey.EntitySetName;
            bool isAttached = false;
            if (context.ObjectStateManager.TryGetObjectStateEntry
                    (context.CreateEntityKey(setName, entity), out entry))
            {
                isAttached = entry.State == EntityState.Detached;
            }
            else
            {
                isAttached = true;
            }

            return isAttached;
        }

    }
}
