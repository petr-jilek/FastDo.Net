namespace ApiCommon.API.Services.General.AppUrl
{
    public interface IAppUrlService
    {
        public string? GetHostUrl();
        public string? CreateHttpsApiUrl(string path);
        public string? CreateHttpsUrl(string path);
    }
}
