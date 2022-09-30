using PetType.Domain;
using PetType.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Queries;

namespace PetType.Service.Queries
{
    public interface IPetCategoryQueryService:IQueryExtension<PetCategoryDTo>
    {
        /* Task<DataCollection<PetCategoryDTo>> GetAllAsync(int page, int take, IEnumerable<int> petcateCategories = null);
        Task<PetCategoryDTo> GetAsync(int id); */
    }
}