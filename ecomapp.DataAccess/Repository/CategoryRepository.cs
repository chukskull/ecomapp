using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecomapp.DataAccess.Data;
using ecomapp.DataAccess.Repository.IRepository;
using ecomapp.Models;

namespace ecomapp.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategory
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.categories.Update(obj);
        }
    }
}