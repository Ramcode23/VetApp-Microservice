using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Common.Collection;

namespace Service.Common.Queries
{
    public interface IQueryExtension<T>
    {
          Task<DataCollection<T>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<T> GetAsync(int id);
    }
}