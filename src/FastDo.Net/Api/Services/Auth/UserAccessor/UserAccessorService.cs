using System.Security.Claims;

namespace FastDo.Net.Api.Services.Auth.UserAccessor
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

        public string? GetToken()
        {
            var authorizationContent = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            var authorizationContentSplitted = authorizationContent?.Split(' ');
            if (authorizationContentSplitted is null || authorizationContentSplitted.Length != 2)
                return null;

            var token = authorizationContent?.Split(' ')[1];

            return token;
        }
    }
}
