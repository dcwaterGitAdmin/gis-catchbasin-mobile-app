using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData
{

    public class BaseRepository<T> : IBaseRepository<T> 
        where T: class
    {
        private readonly IUnitOfWork _unitOfWork;
/*
        public BaseRepository(IDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

 */ 
  #region IBaseRepository<T> Members

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> All()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
