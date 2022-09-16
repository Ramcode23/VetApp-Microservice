

using Service.Common.Collection;
using ServiceType.Service.Queries.DTOs;

namespace ServiceType.Service.Queries;
public class ServiceTypeQueryService : IServiceTypeQueryService
{
    public Task<DataCollection<ServiceTypeDTo>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceTypeDTo> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
}
