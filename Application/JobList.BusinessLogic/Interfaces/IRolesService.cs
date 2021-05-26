using System.Collections.Generic;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<RoleDTO>> GetAllEntitiesAsync();

        Task<RoleDTO> GetEntityByIdAsync(int id);

        Task<RoleDTO> CreateEntityAsync(RoleRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(RoleRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
