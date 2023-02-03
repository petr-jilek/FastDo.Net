namespace FastDo.Net.Api.Services.General.AppUrl
{
    public interface IAppUrlService
    {
        public string? GetHostUrl();
        public string? CreateHttpsApiUrl(string path, bool useHttps = true);
        public string? CreateHttpsUrl(string path, bool useHttps = true);
    }
}
