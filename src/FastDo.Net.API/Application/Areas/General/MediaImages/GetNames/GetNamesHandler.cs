using FastDo.Net.Api.Services.General.FileUpload;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Consts;

namespace FastDo.Net.Application.Areas.General.MediaImages.GetNames
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
            var names = _fileUploadService.GetFileNames(GlobalConsts.MediaImagesFolder);
            return Result<GetNamesResponse>.Ok(new GetNamesResponse() { Items = names, });
        }
    }
}
