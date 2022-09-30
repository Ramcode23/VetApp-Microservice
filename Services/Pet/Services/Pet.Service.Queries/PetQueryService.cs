using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pet.Persistence.Database;
using Pet.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Paging;

namespace Pet.Service.Queries
{
    public class PetQueryService : IPetQueryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PetQueryService(
            ApplicationDbContext _context,
            IMapper _mapper
        )
        {

        }

        public async Task<DataCollection<PetDTo>> GetAllAsync(int page, int take, IEnumerable<int> entities = null)
        {
            var collection = await _context.Pets
                .Where(x => entities == null || entities.Contains(x.Id))
                .OrderBy(x => x.Name)
                .GetPagedAsync(page, take);

            return _mapper.Map<DataCollection<PetDTo>>(collection);
        }

        public async Task<PetDTo> GetAsync(int id)
        {
          var pet = await _context.Pets.SingleAsync(x => x.Id == id);
                    return _mapper.Map<PetDTo>(pet);
        }
    }
}