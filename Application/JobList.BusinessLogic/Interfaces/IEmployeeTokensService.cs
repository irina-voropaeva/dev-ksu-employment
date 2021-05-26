using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface IEmployeeTokensService: ITokensService<EmployeeDTO>
    {
        Task<TokenDTO> CreateTokenByFacebookAsync(FacebookAuthRequest request);
    }
}
