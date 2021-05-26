using System.Collections.Generic;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface ICitiesService
    {
        Task<IEnumerable<CityDTO>> GetAllEntitiesAsync();

        Task<CityDTO> GetEntityByIdAsync(int id);

        Task<CityDTO> CreateEntityAsync(CityRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(CityRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
