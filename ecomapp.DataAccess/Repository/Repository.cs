using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecomapp.DataAccess.Data;
using ecomapp.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


namespace ecomapp.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T Entity)
        {
            dbSet.Add(Entity);

        }

        public T Get(Expression<Func<T, bool>> Filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(Filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;

            return query.ToList();
        }

        public void Remove(T Entity)
        {
            dbSet.Remove(Entity);
        }

        public void RemoveRange(IEnumerable<T> Entities)
        {
            dbSet.RemoveRange(Entities);
        }
    }
}