namespace FastDo.Net.Api.Services.General.AppUrl
{
    public interface IAppUrlService
    {
        string? GetHostUrl();
        string? CreateBaseUrl(bool useHttps = true);
        string? CreateHttpsApiUrl(string path, bool useHttps = true);
        string? CreateHttpsUrl(string path, bool useHttps = true);
    }
}
