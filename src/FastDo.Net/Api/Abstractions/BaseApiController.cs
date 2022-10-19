using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Errors.ErrorMessages;
using Microsoft.AspNetCore.Mvc;

namespace FastDo.Net.Api.Abstractions
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        private readonly IGetErrorMessage _getErrorMessage;

        public BaseApiController(IGetErrorMessage getErrorMessage)
        {
            _getErrorMessage = getErrorMessage;
        }

        protected IActionResult HandleResult<T>(Result<T> result, string languageCode = GlobalConsts.DefaultLanguage)
        {
            if (result.Success)
            {
                if (result.Value is null or EmptyClass)
                    return StatusCode((int)result.StatusCode);

                return StatusCode((int)result.StatusCode, result.Value);
            }

            var errorModel = result.GetErrorModel(_getErrorMessage, languageCode);
            return StatusCode((int)result.StatusCode, errorModel);
        }

        protected IActionResult HandleFileResult(Result<byte[]> result, string contentType, string? fileDownloadName = null, string languageCode = GlobalConsts.DefaultLanguage)
        {
            if (result.Success)
            {
                if (result.Value is null)
                    return StatusCode(StatusCodes.Status500InternalServerError);

                return File(result.Value, contentType, fileDownloadName);
            }

            var errorModel = result.GetErrorModel(_getErrorMessage, languageCode);
            return StatusCode((int)result.StatusCode, errorModel);
        }

        protected IActionResult HandleFileJpegResult(Result<byte[]> result, string? fileDownloadName = null, string languageCode = GlobalConsts.DefaultLanguage)
        {
            return HandleFileResult(result, "image/jpeg", fileDownloadName, languageCode);
        }

        protected IActionResult HandleFileCsvResult(Result<byte[]> result, string? fileDownloadName = null, string languageCode = GlobalConsts.DefaultLanguage)
        {
            return HandleFileResult(result, "text/csv", fileDownloadName, languageCode);
        }
    }
}
