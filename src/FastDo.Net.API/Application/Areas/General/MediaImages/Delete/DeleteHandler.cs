using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.API.Services.General.FileUpload;
using ApiCommon.Domain.Consts;
using ApiCommon.Domain.Error;

namespace ApiCommon.API.Application.Areas.General.MediaImages.Delete
{
    public class DeleteHandler : IHandler
    {
        private readonly IFileUploadService _fileUploadService;

        public DeleteHandler(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public Result<EmptyClass> Handle(string name)
        {
            var ok = _fileUploadService.DeleteFile(ApiCommonConsts.MediaImagesFolder, name);
            return ok == false ? Result<EmptyClass>.BadRequest(Errors.FileNotExists) : Result<EmptyClass>.Ok();
        }
    }
}
