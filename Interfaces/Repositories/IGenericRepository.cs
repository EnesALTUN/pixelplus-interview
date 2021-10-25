using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PixelPlusMulakat.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(object id);
        T GetByCriteria(Expression<Func<T, bool>> filterExpression);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}