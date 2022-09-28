using AutoMapper;
using Identity.Persistence.Database;
using Identity.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Paging;

namespace Identity.Service.Queries;
public class UserQueryService : IUserQueryService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public UserQueryService(
        ApplicationDbContext context,
           IMapper mapper
        )
    {
        _context = context;
    }

    public async Task<DataCollection<UserDto>> GetAllAsync(int page, int take, IEnumerable<string> users = null)
    {
        var collection = await _context.Users
              .Where(x => users == null || users.Contains(x.Id))
              .OrderBy(x => x.FirstName)
              .GetPagedAsync(page, take);
        return _mapper.Map<DataCollection<UserDto>>(collection);

    }

    public async Task<UserDto> GetAsync(string id)
    {
   
        return (await _context.Users.Select(x=> new UserDto{Id=x.Id,FirstName=x.FirstName,LastName=x.LastName,Email=x.Email}
        ).SingleAsync(x=>x.Id==id));
    }
}