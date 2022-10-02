using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using History.Persistense.Database;
using History.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Paging;

namespace History.Service.Queries
{
    public class HistoryQueryService : IHistoryQueryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public HistoryQueryService(ApplicationDbContext context,
                                   IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DataCollection<HistoryDTo>> GetAllAsync(int page, int take, IEnumerable<int> entities = null)
        {
             var collection = await _context.Histories
                .Where(x => entities == null || entities.Contains(x.Id))
                .OrderBy(x => x.Date)
                .GetPagedAsync(page, take);
                
            return _mapper.Map<DataCollection<HistoryDTo>>(collection);
        }

        public async Task<HistoryDTo> GetAsync(int id)
        {
            var history = await _context.Histories.SingleAsync(x => x.Id == id);
                    return _mapper.Map<HistoryDTo>(history);
        }
    }
}