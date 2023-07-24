namespace FastDo.Net.Api.Services.General.FileUpload
{
    public class FileUploadService : IFileUploadService
    {
        private readonly FileUploadServiceSettings _fileUploadServiceSettings;

        public FileUploadService(FileUploadServiceSettings fileUploadServiceSettings)
        {
            _fileUploadServiceSettings = fileUploadServiceSettings;
        }

        private string GetPath(string path)
            => Path.Combine(_fileUploadServiceSettings.UploadsFolderPath!, path);

        private void EnsureDirectoryExists(string dirPath)
        {
            var path = GetPath(dirPath);
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
        }

        private bool FileExists(string filePath)
        {
            var path = GetPath(filePath);
            return File.Exists(path);
        }

        public async Task<bool> UploadFileAsync(string dirPath, IFormFile file, bool overwrite = false,
            string? fileName = null)
        {
            EnsureDirectoryExists(dirPath);
            var path = GetPath(dirPath);

            var filePath = Path.Combine(path, fileName ?? file.FileName);

            if (overwrite == false && FileExists(filePath))
                return false;

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return true;
        }

        public bool UploadFile(string dirPath, byte[] file, string fileName)
        {
            EnsureDirectoryExists(dirPath);
            var path = GetPath(dirPath);

            var filePath = Path.Combine(path, fileName);

            if (FileExists(filePath))
                return false;

            File.WriteAllBytes(filePath, file);
            return true;
        }

        public List<string> GetFileNames(string dirPath)
        {
            EnsureDirectoryExists(dirPath);
            var path = GetPath(dirPath);

            var files = Directory.GetFiles(path);
            var fileNames = files
                .Select(_ => Path.GetFileName(new FileInfo(_).FullName))
                .ToList();

            return fileNames;
        }

        public byte[]? GetFile(string dirPath, string fileName)
        {
            var filePath = Path.Combine(dirPath, fileName);
            if (FileExists(filePath) == false)
                return null;

            var path = GetPath(filePath);
            return File.ReadAllBytes(path);
        }

        public async Task<byte[]?> GetFileAsync(string dirPath, string fileName)
        {
            var filePath = Path.Combine(dirPath, fileName);
            if (FileExists(filePath) == false)
                return null;

            var path = GetPath(filePath);
            return await File.ReadAllBytesAsync(path);
        }

        public bool DeleteFile(string dirPath, string fileName)
        {
            var filePath = Path.Combine(dirPath, fileName);
            if (FileExists(filePath) == false)
                return false;

            var path = GetPath(filePath);
            File.Delete(path);
            return true;
        }

        public bool DeleteAllFiles(string dirPath)
        {
            EnsureDirectoryExists(dirPath);
            var path = GetPath(dirPath);

            var files = Directory.GetFiles(path);
            foreach (var file in files)
                File.Delete(file);

            return true;
        }
    }
}
