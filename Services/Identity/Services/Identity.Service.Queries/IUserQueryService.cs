using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Service.Queries.DTOs;
using Service.Common.Collection;

namespace Identity.Service.Queries
{
    public interface IUserQueryService
    {
         Task<DataCollection<UserDto>> GetAllAsync(int page, int take, IEnumerable<string> users = null);
        Task<UserDto> GetAsync(string id);
    }
}