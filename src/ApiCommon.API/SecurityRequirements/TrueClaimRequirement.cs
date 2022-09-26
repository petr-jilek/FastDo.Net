using Microsoft.AspNetCore.Authorization;

namespace ApiCommon.API.SecurityRequirements
{
    public class TrueClaimRequirement : IAuthorizationRequirement
    {
        public List<string> Claims { get; }

        public TrueClaimRequirement(List<string> claims)
        {
            Claims = claims;
        }
    }

    public class TrueClaimRequirementRequirementHandler : AuthorizationHandler<TrueClaimRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TrueClaimRequirement requirement)
        {
            foreach (var claim in requirement.Claims)
            {
                var claimValue = context.User.Claims.FirstOrDefault(_ => _.Type == claim)?.Value;
                if (claimValue is null)
                    return Task.CompletedTask;
                if (claimValue != true.ToString())
                    return Task.CompletedTask;
            }

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
