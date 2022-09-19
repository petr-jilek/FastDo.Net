using ApiCommon.API.Application.Abstractions;
using ApiCommon.API.Application.Core;
using ApiCommon.API.Services.General.FileUploadService;
using ApiCommon.Domain.Consts;
using ApiCommon.Domain.Error;

namespace ApiCommon.API.Application.Areas.MediaImages.Upload
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
                return Result<EmptyClass>.BadRequest(Errors.FileIsEmpty);
            if (file.Length > ApiCommonConsts.MaxMediaImageSize)
                return Result<EmptyClass>.BadRequest(Errors.FileIsTooLarge);

            var splittedName = file.FileName.Split('.');
            if (splittedName.Length != 2)
                return Result<EmptyClass>.BadRequest(Errors.FileNameIsNotValid);

            var fileExtension = splittedName[1];
            if (ApiCommonConsts.AllowedMediaImageExtensions.Contains(fileExtension) == false)
                return Result<EmptyClass>.BadRequest(Errors.FileTypeIsNotValid);

            var ok = await  _fileUploadService.UploadFileAsync(ApiCommonConsts.MediaImagesFolder, file);
            return ok == false ? Result<EmptyClass>.BadRequest(Errors.FileAlreadyExists) : Result<EmptyClass>.Ok();
        }
    }
}
