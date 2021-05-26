using System.Collections.Generic;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface ISchoolsService
    {
        Task<IEnumerable<SchoolDTO>> GetAllEntitiesAsync();

        Task<SchoolDTO> GetEntityByIdAsync(int id);

        Task<SchoolDTO> CreateEntityAsync(SchoolRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(SchoolRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
