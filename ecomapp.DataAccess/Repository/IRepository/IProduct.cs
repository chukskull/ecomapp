using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecomapp.Models;

namespace ecomapp.DataAccess.Repository.IRepository
{
    public interface IProduct : IRepository<Product>
    {
        void Update(Product obj);

    }
}