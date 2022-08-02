using ApiCommon.Application.Interfaces;
using System.Security.Claims;

namespace ApiCommon.API.Services
{
    public class UserAccessorService : IUserAccessorService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessorService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetId()
            => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public string? GetEmail()
            => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

        public string? GetUserName()
            => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);

        public bool IsAuthenticated()
            => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
