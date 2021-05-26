using System.Collections.Generic;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IWorkAreasService
    {
        Task<IEnumerable<WorkAreaDTO>> GetAllEntitiesAsync();

        Task<WorkAreaDTO> GetEntityByIdAsync(int id);

        Task<WorkAreaDTO> CreateEntityAsync(WorkAreaRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(WorkAreaRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
