using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApiCommon.Domain.Security
{
    public class UserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetEmail()
            => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

        public bool IsAuthenticated()
            => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}