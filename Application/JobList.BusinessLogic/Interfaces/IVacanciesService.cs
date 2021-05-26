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
    public interface IVacanciesService
    {
        Task<IEnumerable<VacancyDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<VacancyDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery urlQuery = null);

        Task<IEnumerable<VacancyDTO>> GetFilteredEntitiesAsync(VacancyUrlQuery vacancyUrlQuery = null, 
                                                               SearchingUrlQuery searchingUrlQuery = null, 
                                                               SortingUrlQuery sortingUrlQuery = null, 
                                                               PaginationUrlQuery paginationUrlQuery = null);

        Task<IEnumerable<VacancyDTO>> GetFilteredEntitiesAsync(int? recruiterId, 
                                                               string searchString,
                                                               PaginationUrlQuery paginationUrlQuery = null);

        Task<IEnumerable<VacancyDTO>> GetVacanciesByRecruiterIdAsync(int recruiterId, PaginationUrlQuery urlQuery = null);

        Task<VacancyDTO> GetEntityByIdAsync(int id);

        Task<VacancyDTO> CreateEntityAsync(VacancyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(VacancyRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
        
        Task<int> CountAsync(Expression<Func<Vacancy, bool>> predicate = null);

        int TotalRecords { get; }
    }
}
