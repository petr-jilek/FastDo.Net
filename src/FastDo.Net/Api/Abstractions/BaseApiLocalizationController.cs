using FastDo.Net.Api.Services.General.Localization;
using FastDo.Net.Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace FastDo.Net.Api.Abstractions
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
