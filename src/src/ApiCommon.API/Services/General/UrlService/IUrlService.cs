namespace ApiCommon.API.Services.General.UrlService
{
    public interface IUrlService
    {
        public string? GetHostUrl();
        public string? CreateHttpsApiUrl(string path);
        public string? CreateHttpsUrl(string path);
    }
}
