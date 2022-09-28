using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Common.Collection;
using Service.Common.Queries;
using ServiceType.Service.Queries.DTOs;

namespace ServiceType.Service.Queries
{
    public interface IServiceTypeQueryService
    {
        Task<DataCollection<ServiceTypeDTo>> GetAllAsync(int page, int take, IEnumerable<int>? serviceCategories);
         Task<ServiceTypeDTo> GetAsync(int id);
    }
}