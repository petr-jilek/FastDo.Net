﻿using FastDo.Net.Api.Services.General.FileUpload;
using FastDo.Net.Application.Abstractions;
using FastDo.Net.Application.Core;
using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Errors;

namespace FastDo.Net.Application.Areas.General.MediaImages.Delete
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
            var ok = _fileUploadService.DeleteFile(GlobalConsts.MediaImagesFolder, name);
            return ok == false ? Result<EmptyClass>.BadRequest(FastDoErrorCodes.FileNotExists) : Result<EmptyClass>.Ok();
        }
    }
}
