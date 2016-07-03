using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace test2.EntityDao.GenericDao
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
