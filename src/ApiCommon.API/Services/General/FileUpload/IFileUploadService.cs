namespace ApiCommon.API.Services.General.FileUpload
{
    public interface IFileUploadService
    {
        Task<bool> UploadFileAsync(string dirPath, IFormFile file, bool overwrite = false);
        List<string> GetFileNames(string dirPath);
        byte[]? GetFile(string dirPath, string fileName);
        bool DeleteFile(string dirPath, string fileName);
    }
}
