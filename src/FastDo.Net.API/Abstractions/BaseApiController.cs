using FastDo.Net.Api.Application.Core;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Error;
using Microsoft.AspNetCore.Mvc;

namespace FastDo.Net.Api.Abstractions
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        protected ActionResult HandleResult<T>(Result<T> result, string languageCode = GlobalConsts.DefaultLanguage)
        {
            if (result.Success)
            {
                if (result.Value is null or EmptyClass)
                    return StatusCode((int)result.StatusCode);

                return StatusCode((int)result.StatusCode, result.Value);
            }

            if (result.Error is null)
                return StatusCode((int)result.StatusCode,
                    ErrorModels.GetErrorModel(Errors.UnknownError, languageCode));

            var errorModel = ErrorModels.GetErrorModel(result.Error, languageCode);
            errorModel.Detail = result.ErrorDetail ?? errorModel.Message;
            return StatusCode((int)result.StatusCode, errorModel);
        }
    }
}
