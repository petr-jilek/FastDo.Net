using ApiCommon.API.Application.Core;
using ApiCommon.API.Services.General.Localization;
using ApiCommon.Domain.Error;
using Microsoft.AspNetCore.Mvc;

namespace ApiCommon.API.Abstractions
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiLocalizationController : BaseApiController
    {
        private readonly ILocalizationService _localizationService;

        public BaseApiLocalizationController(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        protected ActionResult HandleLocalizedResult<T>(Result<T> result)
            => HandleResult(result, _localizationService.GetLanguageCode());
    }
}
