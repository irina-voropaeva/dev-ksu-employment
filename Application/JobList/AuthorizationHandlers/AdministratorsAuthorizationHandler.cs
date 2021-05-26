using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace KsuEmployment.Api.AuthorizationHandlers
{
    public class AdministratorsAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, int>
    {
        protected override Task HandleRequirementAsync( AuthorizationHandlerContext context,
                                                        OperationAuthorizationRequirement requirement,
                                                        int id)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do everything.
            if (context.User.IsInRole("admin"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
