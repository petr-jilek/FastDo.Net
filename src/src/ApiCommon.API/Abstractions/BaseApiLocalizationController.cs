using ApiCommon.Application.Core;
using ApiCommon.Application.Services.Interfaces.General;
using ApiCommon.Domain.Error;
using Microsoft.AspNetCore.Mvc;

namespace ApiCommon.API.Abstractions
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiLocalizationController : ControllerBase
    {
        private readonly ILocalizationService _localizationService;

        public BaseApiLocalizationController(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

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
                return StatusCode((int)result.StatusCode, _localizationService.GetErrorModel(result.Error));

            if (result.ErrorModel is not null)
                return StatusCode((int)result.StatusCode, result.ErrorModel);

            return StatusCode((int)result.StatusCode, _localizationService.GetErrorModel(Errors.UnkonwnError));
        }
    }
}
