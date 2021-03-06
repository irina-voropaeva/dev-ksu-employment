using System.Collections.Generic;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IFavoriteVacanciesService
    {
        Task<IEnumerable<FavoriteVacancyDTO>> GetAllEntitiesAsync();

        Task<FavoriteVacancyDTO> GetEntityByIdAsync(int id);

        Task<FavoriteVacancyDTO> CreateEntityAsync(FavoriteVacancyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(FavoriteVacancyRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
