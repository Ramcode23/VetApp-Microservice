using PetType.Domain;
using PetType.Service.Queries.DTOs;
using Service.Common.Collection;

namespace PetType.Service.Queries
{
    public interface IPetCategoryQueryService
    {
        Task<DataCollection<PetCategoryDTo>> GetAllAsync(int page, int take, IEnumerable<int> petcateCategories = null);
        Task<PetCategoryDTo> GetAsync(int id);
    }
}