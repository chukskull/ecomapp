using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecomapp.Models;

namespace ecomapp.DataAccess.Repository.IRepository
{
    public interface ICategory : IRepository<Category>
    {
        void Update(Category obj);
    }
}