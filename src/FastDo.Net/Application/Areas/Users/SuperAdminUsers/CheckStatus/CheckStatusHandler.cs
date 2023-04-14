using FastDo.Net.Api.Services.Auth.Token;
using FastDo.Net.Api.Services.Auth.UserAccessor;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;

namespace FastDo.Net.Application.Areas.Users.SuperadminUsers.CheckStatus
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
