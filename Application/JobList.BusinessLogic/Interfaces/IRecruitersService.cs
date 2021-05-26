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
    public interface IRecruitersService
    {
        Task<IEnumerable<RecruiterDTO>> GetAllRecruitersAsync();

        Task<RecruiterDTO> GetRecruiterByIdAsync(int id);

        Task<IEnumerable<RecruiterDTO>> GetRecruitersByCompanyIdAsync(int companyId, PaginationUrlQuery urlQuery = null);

        Task<IEnumerable<RecruiterDTO>> GetFilteredRecruitersAsync(SearchingUrlQuery searchingUrlQuery = null, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);


        Task<IEnumerable<RecruiterDTO>> GetFilteredRecruitersAsync(int? companyId = null,
                                                                   string searchString = null,
                                                                   SortingUrlQuery sortingUrlQuery = null,
                                                                   PaginationUrlQuery paginationUrlQuery = null);

        Task<RecruiterDTO> CreateRecruiterAsync(RecruiterRequest modelRequest);

        Task<bool> UpdateRecruiterByIdAsync(RecruiterUpdateRequest modelRequest, int id);

        Task<bool> ResetEntityByIdAsync(RecruierResetPasswordRequest modelRequest, int id);

        Task<bool> DeleteRecruiterByIdAsync(int id);
        
        Task<int> CountAsync(Expression<Func<Recruiter, bool>> predicate = null);

        int TotalRecords { get; }
    }
}
