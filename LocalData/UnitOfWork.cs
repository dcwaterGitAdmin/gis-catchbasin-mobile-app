using System;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using EntityState = System.Data.EntityState;

namespace DCWaterMobile.LocalData
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
       
        private DbContext _session;
        public DbContext Session
        {
            get { return _session; }
        }

        public UnitOfWork()
        {
            _session = new MxDataModel();
        }
/*
        public UnitOfWork(string connectionString)
        {
            _session = new MxDataModel(connectionString);
        }
        public UnitOfWork(EntityConnection connection)
        {
            _session = new MxDataModel(connection);
        }
*/
        private bool _isInTransaction = false;

        public bool IsInTransaction
        {
            get { return _isInTransaction; }
        }
        public void BeginTransaction()
        {
            _session = new MxDataModel();
            _isInTransaction = true;
        }

        public void RollbackTransaction()
        {
            _session = new MxDataModel();
            _isInTransaction = false;
        }

        public void CommitTransaction()
        {
            try
            {
                if (_isInTransaction == false)
                {
                    throw new EntityException("The Unit of Work ");
                }

                //_session.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                _isInTransaction = false;
            }
            catch (Exception exception)
            {
                _session = new MxDataModel();
                _isInTransaction = false;
                throw new EntityException(
                   "An error occurred during the Commit of the transaction.",
                   exception);
            }
        }
     #region IUnitOfWork Members

        public void MarkNew<T>(T entity) where T : class
        {
            if (typeof(T) is EntityObject)
            {
                var newEntity = entity as EntityObject;
                string setName = ((EntityObject) newEntity).EntityKey.EntitySetName;
                //_session.AddObject(setName, entity);
            }
        }

        public void MarkDirty<T>(T entity) where T : class
        {
            if (typeof(T) is EntityObject)
            {
                var modifiedEntity = entity as EntityObject;
                if (modifiedEntity == null)
                {
                    throw new EntityException("The current entity is not of type EntityObject.");
                }

                string setName = ((EntityObject)modifiedEntity).EntityKey.EntitySetName;
/*
                if (!_session.IsAttachedTo(entity))
                {
                    //_session.AttachTo(setName, entity);
                }
                if (modifiedEntity.EntityState != EntityState.Modified)
                {
                   // _session.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
 */
            }
        }

        public void MarkDeleted<T>(T entity) where T : class
        {
            if (typeof(T) is EntityObject)
            {
                var deletedEntity = entity as EntityObject;
                if (deletedEntity == null)
                {
                    throw new EntityException("The current entity is not of type EntityObject.");
                }

                string setName = ((EntityObject)deletedEntity).EntityKey.EntitySetName;
/*
                if (!_session.IsAttachedTo(entity))
                {
                   // _session.AttachTo(setName, entity);
                }
                if (deletedEntity.EntityState != EntityState.Deleted)
                {
                   // _session.DeleteObject(entity);
                }
 */
            }
        }

    #endregion

#region Implementation of IDisposable
        public void Dispose()
        {
            if (_session != null)
            {
/*
                if (_session.Connection.State != ConnectionState.Closed)
                {
                    _session.Connection.Close();
                }
 */
                _session.Dispose();
            }
            GC.SuppressFinalize(true);
        }
#endregion 
    
    }
}
