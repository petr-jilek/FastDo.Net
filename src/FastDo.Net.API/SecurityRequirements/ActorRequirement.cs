using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FastDo.Net.Api.SecurityRequirements
{
    public class ActorRequirement : IAuthorizationRequirement
    {
        public string Actor { get; }

        public ActorRequirement(string actor)
        {
            Actor = actor;
        }
    }

    public class ActorRequirementHandler : AuthorizationHandler<ActorRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ActorRequirement requirement)
        {
            if (context.User.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Actor)?.Value == requirement.Actor)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
