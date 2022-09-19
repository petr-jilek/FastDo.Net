using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.API.Services.General.FileUploadService;
using ApiCommon.Domain.Consts;

namespace ApiCommon.API.Application.Areas.General.MediaImages.GetNames
{
    public class GetNamesHandler : IHandler
    {
        private readonly IFileUploadService _fileUploadService;

        public GetNamesHandler(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public Result<GetNamesResponse> Handle()
        {
            var names = _fileUploadService.GetFileNames(ApiCommonConsts.MediaImagesFolder);
            return Result<GetNamesResponse>.Ok(new GetNamesResponse() { Items = names, });
        }
    }
}
