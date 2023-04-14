namespace FastDo.Net.Api.Services.General.FileUpload
{
    public interface IFileUploadService
    {
        Task<bool> UploadFileAsync(string dirPath, IFormFile file, bool overwrite = false,
            string? fileName = null);
        bool UploadFile(string dirPath, byte[] file, string fileName);
        List<string> GetFileNames(string dirPath);
        byte[]? GetFile(string dirPath, string fileName);
        bool DeleteFile(string dirPath, string fileName);
        bool DeleteAllFiles(string dirPath);
    }
}
