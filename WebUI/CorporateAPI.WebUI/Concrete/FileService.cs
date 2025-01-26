using CorporateAPI.WebUI.Abstract;

namespace CorporateAPI.WebUI.Concrete
{
    public class FileService : IFileService
    {
        private readonly string _rootPath;

        public FileService(IWebHostEnvironment env)
        {
            _rootPath = env.WebRootPath; // wwwroot yolunu al
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Dosya yüklenemedi. Lütfen geçerli bir dosya seçin.");

            // Dosyanın yükleneceği klasör yolunu oluştur
            string uploadFolder = Path.Combine(_rootPath, folderName);
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Benzersiz dosya adı oluştur
            string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            string filePath = Path.Combine(uploadFolder, uniqueFileName);

            // Dosyayı klasöre kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Kaydedilen dosyanın yolunu döndür
            return Path.Combine(folderName, uniqueFileName).Replace("\\", "/");
        }

        public async Task DeleteFileAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;

            string fullPath = Path.Combine(_rootPath, filePath);
            if (File.Exists(fullPath))
            {
                await Task.Run(() => File.Delete(fullPath));
            }
        }

        public string GetFileUrl(string filePath)
        {
            return $"/{filePath.Replace("\\", "/")}";
        }
    }
}
