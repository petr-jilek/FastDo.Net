using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ApiCommon.API.SecurityRequirements
{
    public class VerifiedPhoneNumberRequirement : IAuthorizationRequirement
    {
    }

    public class VerifiedPhoneNumberRequirementHandler : AuthorizationHandler<VerifiedPhoneNumberRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            VerifiedPhoneNumberRequirement requirement)
        {
            var phoneNumberConfirmed = context.User.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.MobilePhone)?.Value;
            if (phoneNumberConfirmed == true.ToString())
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
