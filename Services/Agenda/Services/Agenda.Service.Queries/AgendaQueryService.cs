using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Persistense.Database;
using Agenda.Service.Queries.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Paging;

namespace Agenda.Service.Queries
{
    public class AgendaQueryService : IAgendaQueryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AgendaQueryService(
                     ApplicationDbContext context,
                      IMapper mapper
        )
        {

        }
        
        public async Task<DataCollection<AgendaDTO>> GetAllAsync(int page, int take, IEnumerable<int> entities = null)
        {
            var collection = await _context.Agendas
                  .Where(x => entities == null || entities.Contains(x.Id))
                  .OrderBy(x => x.Date)
                  .GetPagedAsync(page, take);

            return _mapper.Map<DataCollection<AgendaDTO>>(collection);
        }

        public async Task<AgendaDTO> GetAsync(int id)
        {
          var agenda = await _context.Agendas.SingleAsync(x => x.Id == id);
                    return _mapper.Map<AgendaDTO>(agenda);
        }
    }
}