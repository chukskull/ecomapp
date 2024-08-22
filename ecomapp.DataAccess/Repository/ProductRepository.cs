using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecomapp.DataAccess.Data;
using ecomapp.DataAccess.Repository.IRepository;
using ecomapp.Models;

namespace ecomapp.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProduct
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}