using System.Collections.Generic;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IResumeLanguagesService
    {
        Task<IEnumerable<ResumeLanguageDTO>> GetAllEntitiesAsync();

        Task<ResumeLanguageDTO> GetEntityByIdAsync(int id);

        Task<ResumeLanguageDTO> CreateEntityAsync(ResumeLanguageRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(ResumeLanguageRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
