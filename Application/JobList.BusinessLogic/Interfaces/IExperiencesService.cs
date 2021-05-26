using System.Collections.Generic;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IExperiencesService
    {
        Task<IEnumerable<ExperienceDTO>> GetAllEntitiesAsync();

        Task<ExperienceDTO> GetEntityByIdAsync(int id);

        Task<ExperienceDTO> CreateEntityAsync(ExperienceRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(ExperienceRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
