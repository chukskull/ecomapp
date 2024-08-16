using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ecomapp.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> Filter);
        void Add(T Entity);
        void Remove(T Entity);

        void RemoveRange(IEnumerable<T> Entities);

    }
}
