namespace FastDo.Net.Api.Services.Auth.UserAccessor
{
    public class UserAccessorDevelopmentService : IUserAccessorService
    {
        private readonly UserAccessorDevelopmentServiceSettings _settings;

        public UserAccessorDevelopmentService(UserAccessorDevelopmentServiceSettings settings)
        {
            _settings = settings;
        }

        public string? GetEmail()
        {
            throw new NotImplementedException();
        }

        public string? GetId() => _settings.Id;

        public string? GetToken()
        {
            throw new NotImplementedException();
        }

        public string? GetUserName()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated()
        {
            throw new NotImplementedException();
        }
    }
}
