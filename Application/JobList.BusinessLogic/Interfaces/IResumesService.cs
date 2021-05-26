using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.UrlQuery;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Pagination;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IResumesService
    {
        Task<IEnumerable<ResumeDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<ResumeDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery urlQuery = null);

        Task<IEnumerable<ResumeDTO>> GetFilteredEntitiesAsync(ResumeUrlQuery resumeUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);

        Task<ResumeDTO> GetEntityByIdAsync(int id);

        Task<ResumeDTO> CreateEntityAsync(ResumeRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(ResumeRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        Task<int> CountAsync(Expression<Func<Resume, bool>> predicate = null);

        int TotalRecords { get; }
    }
}
