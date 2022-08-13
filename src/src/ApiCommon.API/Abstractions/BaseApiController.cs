using ApiCommon.Application.Core;
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
                if (result.Value is null || result.Value is EmptyClass)
                    return StatusCode((int)result.StatusCode);

                return StatusCode((int)result.StatusCode, result.Value);
            }

            if (result.Error is not null)
                return StatusCode((int)result.StatusCode, result.Error);

            return StatusCode((int)result.StatusCode, Errors.UndescriptedError);
        }
    }
}
