using System.Collections.Generic;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IFacultiesService
    {
        Task<IEnumerable<FacultyDTO>> GetAllEntitiesAsync();

        Task<FacultyDTO> GetEntityByIdAsync(int id);

        Task<FacultyDTO> CreateEntityAsync(FacultyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(FacultyRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
