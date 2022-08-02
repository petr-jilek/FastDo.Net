﻿namespace ApiCommon.Application.Interfaces
{
    public interface IUrlService
    {
        public string? GetHostUrl();
        public string? CreateHttpsApiUrl(string path);
    }
}