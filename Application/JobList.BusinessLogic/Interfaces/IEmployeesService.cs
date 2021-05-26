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

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<EmployeeDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery paginationUrlQuery = null);

        Task<IEnumerable<EmployeeDTO>> GetFilteredEntitiesAsync(SearchingUrlQuery searchingUrlQuery, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);

        Task<EmployeeDTO> GetEntityByIdAsync(int id);
        
        Task<EmployeeDTO> CreateEntityAsync(EmployeeRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(EmployeeUpdateRequest modelRequest, int id);

        Task<bool> ResetEntityByIdAsync(EmployeeResetPasswordRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        Task<int> CountAsync(Expression<Func<Employee, bool>> predicate = null);

        Task<bool> ExistAsync(Expression<Func<Employee, bool>> predicate);

        int TotalRecords { get; }
    }
}
