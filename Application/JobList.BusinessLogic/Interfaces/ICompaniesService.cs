using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.Sorting;
using KsuEmployment.Common.UrlQuery;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Pagination;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface ICompaniesService
    {
        Task<IEnumerable<CompanyDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<CompanyDTO>> GetFilteredEntitiesAsync(SearchingUrlQuery searchingUrlQuery = null, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);

        Task<CompanyDTO> GetEntityByIdAsync(int id);

        Task<CompanyDTO> CreateEntityAsync(CompanyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(CompanyUpdateRequest modelRequest, int id);

        Task<bool> ResetEntityByIdAsync(CompanyResetPasswordRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        Task<int> CountAsync(Expression<Func<Company, bool>> predicate = null);

        int TotalRecords { get; }
    }
}
