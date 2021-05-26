using System.Collections.Generic;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IEducationPeriodsService
    {
        Task<IEnumerable<EducationPeriodDTO>> GetAllEntitiesAsync();

        Task<EducationPeriodDTO> GetEntityByIdAsync(int id);

        Task<EducationPeriodDTO> CreateEntityAsync(EducationPeriodRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(EducationPeriodRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
