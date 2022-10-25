using FastDo.Net.Api.Services.General.FileUpload;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Errors;

namespace FastDo.Net.Application.Areas.General.MediaImages.Upload
{
    public class UploadHandler : IHandler
    {
        private readonly IFileUploadService _fileUploadService;

        public UploadHandler(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public async Task<Result<EmptyClass>> Handle(IFormFile file)
        {
            if (file is null)
                return Result<EmptyClass>.BadRequest(FastDoErrorCodes.FileIsEmpty);
            if (file.Length > GlobalConsts.MaxMediaImageSize)
                return Result<EmptyClass>.BadRequest(FastDoErrorCodes.FileIsTooLarge);

            var splittedName = file.FileName.Split('.');
            if (splittedName.Length != 2)
                return Result<EmptyClass>.BadRequest(FastDoErrorCodes.FileNameIsNotValid);

            var fileExtension = splittedName[1];
            if (GlobalConsts.AllowedMediaImageExtensions.Contains(fileExtension) == false)
                return Result<EmptyClass>.BadRequest(FastDoErrorCodes.FileTypeIsNotValid);

            var ok = await _fileUploadService.UploadFileAsync(GlobalConsts.MediaImagesFolder, file);
            return ok == false ? Result<EmptyClass>.BadRequest(FastDoErrorCodes.FileAlreadyExists) : Result<EmptyClass>.Ok();
        }
    }
}
