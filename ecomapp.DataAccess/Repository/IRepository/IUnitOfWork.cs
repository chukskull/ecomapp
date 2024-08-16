using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomapp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        void Save();
        ICategory category { get; }

    }
}