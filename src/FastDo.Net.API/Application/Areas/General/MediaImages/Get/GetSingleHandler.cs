using FastDo.Net.Api.Services.General.FileUpload;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Error;

namespace FastDo.Net.Application.Areas.General.MediaImages.Get
{
    public class GetSingleHandler : IHandler
    {
        private readonly IFileUploadService _fileUploadService;

        public GetSingleHandler(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public Result<byte[]> Handle(string name)
        {
            var file = _fileUploadService.GetFile(GlobalConsts.MediaImagesFolder, name);
            return file is null ? Result<byte[]>.BadRequest(Errors.FileNotExists) : Result<byte[]>.Ok(file);
        }
    }
}
