using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetType.Domain;
using PetType.Persistence.Database;
using PetType.Persistense.Database;
using PetType.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Paging;

namespace PetType.Service.Queries
{
    public class PetCategoryQueryService : IPetCategoryQueryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PetCategoryQueryService(
            ApplicationDbContext context,
              IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<DataCollection<PetCategoryDTo>> GetAllAsync(int page, int take, IEnumerable<int>? categories = null)
        {
            var collection = await _context.PetCategories
                .Where(x => categories == null || categories.Contains(x.Id))
                .OrderBy(x => x.Name)
                .GetPagedAsync(page, take);

            return _mapper.Map<DataCollection<PetCategoryDTo>>(collection);
        }

        public async Task<PetCategoryDTo> GetAsync(int id)
        {

            return await _context.PetCategories
                .Select(x => new PetCategoryDTo { Id = x.Id, Name = x.Name })
                .SingleAsync(x => x.Id == id);
        }
    }
}