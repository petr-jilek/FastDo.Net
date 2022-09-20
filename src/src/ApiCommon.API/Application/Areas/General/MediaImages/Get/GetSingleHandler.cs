using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.API.Services.General.FileUpload;
using ApiCommon.Domain.Consts;
using ApiCommon.Domain.Error;

namespace ApiCommon.API.Application.Areas.General.MediaImages.Get
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
            var file = _fileUploadService.GetFile(ApiCommonConsts.MediaImagesFolder, name);
            return file is null ? Result<byte[]>.BadRequest(Errors.FileNotExists) : Result<byte[]>.Ok(file);
        }
    }
}
