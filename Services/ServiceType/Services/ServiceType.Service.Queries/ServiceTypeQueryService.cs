

using AutoMapper;
using Service.Common.Collection;
using ServiceType.Persistese.Database;
using ServiceType.Service.Queries.DTOs;
using Service.Common.Queries;
using Service.Common.Paging;
using Microsoft.EntityFrameworkCore;

namespace ServiceType.Service.Queries;
public class ServiceTypeQueryService : IServiceTypeQueryService
{

    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ServiceTypeQueryService(ApplicationDbContext context,
    IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DataCollection<ServiceTypeDTo>> GetAllAsync(int page, int take, IEnumerable<int> serviceCategories = null)
    {
  var collection = await _context.ServiceCategories
                .Where(x => serviceCategories == null || serviceCategories.Contains(x.Id))
                .OrderBy(x => x.Name)
                .GetPagedAsync(page, take);

            return _mapper.Map<DataCollection<ServiceTypeDTo>>(collection);
    }

    public async Task<ServiceTypeDTo> GetAsync(int id)
    {
 return await _context.ServiceCategories
                .Select(x => new ServiceTypeDTo { Id = x.Id, Name = x.Name })
                .SingleAsync(x => x.Id == id);
    }
}
