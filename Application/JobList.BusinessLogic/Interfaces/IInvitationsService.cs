using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Pagination;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IInvitationsService
    {
        Task<IEnumerable<InvitationDTO>> GetAllInvitationsAsync();

        Task<InvitationDTO> GetInvitationByIdAsync(int id);

        Task<IEnumerable<InvitationDTO>> GetInvitationsByEmployeeIdAsync(int employeeId, PaginationUrlQuery urlQuery = null);

        Task<InvitationDTO> CreateInvitationAsync(InvitationRequest request);

        Task<bool> UpdateInvitationByIdAsync(InvitationRequest request, int id);

        Task<bool> DeleteInvitationByIdAsync(int id);

        Task<int> CountAsync(Expression<Func<Invitation, bool>> predicate = null);
    }
}
