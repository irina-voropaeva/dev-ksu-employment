using System.Collections.Generic;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface ILanguagesService
    {
        Task<IEnumerable<LanguageDTO>> GetAllEntitiesAsync();

        Task<LanguageDTO> GetEntityByIdAsync(int id);

        Task<LanguageDTO> CreateEntityAsync(LanguageRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(LanguageRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
