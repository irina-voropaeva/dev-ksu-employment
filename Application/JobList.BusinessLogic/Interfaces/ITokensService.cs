using System.Threading.Tasks;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Interfaces
{
    public interface ITokensService<T>
    {
        Task<TokenDTO> CreateTokenAsync(LoginRequest request);
        string GenerateJWT(T entity);
        string GenerateRefreshToken();
        Task<TokenDTO> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
