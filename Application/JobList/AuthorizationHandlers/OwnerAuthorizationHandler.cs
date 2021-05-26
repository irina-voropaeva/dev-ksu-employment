using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace KsuEmployment.Api.AuthorizationHandlers
{
    public class OwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, int>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       OperationAuthorizationRequirement requirement,
                                                       int id)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value == id.ToString())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

}
