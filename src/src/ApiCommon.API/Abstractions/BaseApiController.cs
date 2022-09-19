using ApiCommon.API.Application.Core;
using ApiCommon.Domain.Consts;
using ApiCommon.Domain.Error;
using Microsoft.AspNetCore.Mvc;

namespace ApiCommon.API.Abstractions
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result is null)
                return NotFound();

            if (result.Success)
            {
                if (result.Value is null or EmptyClass)
                    return StatusCode((int)result.StatusCode);

                return StatusCode((int)result.StatusCode, result.Value);
            }

            if (result.Error is not null)
                return StatusCode((int)result.StatusCode,
                    ErrorModels.GetErrorModel(result.Error, ApiCommonConsts.DefaultLanguage));

            if (result.ErrorModel is not null)
                return StatusCode((int)result.StatusCode, result.ErrorModel);

            return StatusCode((int)result.StatusCode,
                ErrorModels.GetErrorModel(Errors.UnknownError, ApiCommonConsts.DefaultLanguage));
        }
    }
}
