using FastDo.Net.Api.Services.General.Localization;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Errors.ErrorMessages;
using Microsoft.AspNetCore.Mvc;

namespace FastDo.Net.Api.Abstractions
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiLocalizedController : BaseApiController
    {
        private readonly ILocalizationService _localizationService;

        public BaseApiLocalizedController(ILocalizationService localizationService, IGetErrorMessage getErrorMessage) : base(getErrorMessage)
        {
            _localizationService = localizationService;
        }      

        protected IActionResult HandleResult<T>(Result<T> result)
            => HandleResult(result, _localizationService.GetLang());

        protected IActionResult HandleFileResult(Result<byte[]> result, string contentType, string? fileDownloadName = null)
            => HandleFileResult(result, contentType, fileDownloadName, _localizationService.GetLang());

        protected IActionResult HandleFileJpegResult(Result<byte[]> result, string? fileDownloadName = null)
            => HandleFileJpegResult(result, fileDownloadName, _localizationService.GetLang());

        protected IActionResult HandleFileCsvResult(Result<byte[]> result, string? fileDownloadName = null)
            => HandleFileCsvResult(result, fileDownloadName, _localizationService.GetLang());
    }
}
