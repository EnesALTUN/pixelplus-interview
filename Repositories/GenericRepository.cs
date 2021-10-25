using Microsoft.EntityFrameworkCore;
using PixelPlusMulakat.Data;
using PixelPlusMulakat.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PixelPlusMulakat.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private PixelPlusDBContext _context;
        private DbSet<T> table;

        public GenericRepository(PixelPlusDBContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Delete(object id)
        {
            T exist = table.Find(id);
            table.Remove(exist);
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetByCriteria(Expression<Func<T, bool>> filterExpression)
        {
            return table.Where(filterExpression).FirstOrDefault();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}