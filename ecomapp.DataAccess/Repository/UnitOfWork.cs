using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecomapp.DataAccess.Data;
using ecomapp.DataAccess.Repository.IRepository;
using ecomapp.Models;

namespace ecomapp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategory category { get; private set; }
        public IProduct product { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            category = new CategoryRepository(_db);
            product = new ProductRepository(db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}