using ApiCommon.Application.Abstractions;
using ApiCommon.Application.Core;
using ApiCommon.Application.Services.Interfaces.Auth;

namespace ApiCommon.Application.Areas.Users.SuperAdminUsers.CheckStatus
{
    public class CheckStatusHandler : IHandler
    {
        private readonly IUserAccessorService _userAccessorService;
        private readonly ITokenService _tokenService;

        public CheckStatusHandler(IUserAccessorService userAccessorService, ITokenService tokenService)
        {
            _userAccessorService = userAccessorService;
            _tokenService = tokenService;
        }

        public async Task<Result<CheckStatusResponse>> Handle()
        {
            var token = _userAccessorService.GetToken();
            if (token is null)
                return Result<CheckStatusResponse>.Ok(new CheckStatusResponse() { IsValid = false, });

            var isValid = await _tokenService.IsTokenValidAsync(token);

            return Result<CheckStatusResponse>.Ok(new CheckStatusResponse() { IsValid = isValid, });
        }
    }
}
