using ApiCommon.Domain.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace ApiCommon.Domain.Abstraction
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result is null)
                return NotFound();

            if (result.Success)
            {
                if (result.Value is not null)
                    return StatusCode((int)result.StatusCode, result.Value);

                if (result.Value is null)
                    return StatusCode((int)result.StatusCode);
            }

            if (result.Error is not null)
                return StatusCode((int)result.StatusCode, result.Error);

            return StatusCode((int)result.StatusCode);
        }
    }
}