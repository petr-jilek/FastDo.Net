using FastDo.Net.Api.Services.General.FileUpload;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Errors;

namespace FastDo.Net.Application.Areas.General.MediaImages.DeleteAll
{
    public class DeleteAllHandler : IHandler
    {
        private readonly IFileUploadService _fileUploadService;

        public DeleteAllHandler(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public Result<EmptyClass> Handle()
        {
            var ok = _fileUploadService.DeleteAllFiles(GlobalConsts.MediaImagesFolder);
            return ok == false ? Result<EmptyClass>.BadRequest(FastDoErrorCodes.UndescribedError) : Result<EmptyClass>.Ok();
        }
    }
}
