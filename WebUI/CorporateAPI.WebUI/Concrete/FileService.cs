using CorporateAPI.WebUI.Abstract;

namespace CorporateAPI.WebUI.Concrete
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        // Dosya Kaydet
        public async Task<string> SaveFileAsync(IFormFile file, string subDirectory)
        {
            // Web root içinde 'uploads' altındaki ilgili dizin yolunu belirle
            string uploadDirectory = Path.Combine(_env.WebRootPath, "uploads", subDirectory);

            // Klasör oluşturma kontrolü
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory); // Eğer yoksa klasör oluşturuluyor
            }

            // Dosya adı ve yolu
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploadDirectory, fileName);

            // Dosyayı kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream); // Dosyayı kaydediyoruz
            }

            return fileName; // Dosyanın sadece adını döndürüyoruz
        }

        // Dosya Sil
        public async Task<bool> DeleteFileAsync(string fileName, string subDirectory)
        {
            string filePath = Path.Combine(_env.WebRootPath, "uploads", subDirectory, fileName);

            // Dosya var mı kontrol et
            if (File.Exists(filePath))
            {
                File.Delete(filePath); // Dosyayı sil
                return true; // Başarıyla silindi
            }

            return false; // Dosya bulunamadı
        }

        // Dosya Güncelle
        public async Task<string> UpdateFileAsync(string oldFileName, IFormFile newFile, string subDirectory)
        {
            // Web root içindeki ilgili dizin yolunu belirle
            string directoryPath = Path.Combine(_env.WebRootPath, "uploads", subDirectory);

            // Eğer klasör yoksa oluşturuluyor
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath); // Klasör oluşturuluyor
            }

            // Eski dosyayı silme işlemi
            if (!string.IsNullOrEmpty(oldFileName))
            {
                string oldFilePath = Path.Combine(directoryPath, oldFileName);
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath); // Eski dosya siliniyor
                }
            }

            // Yeni dosya ismini alıyoruz
            string newFileName = Path.GetFileName(newFile.FileName);

            // Yeni dosya yolunu oluşturuyoruz
            string newFilePath = Path.Combine(directoryPath, newFileName);

            // Yeni dosyayı kaydediyoruz
            using (var stream = new FileStream(newFilePath, FileMode.Create))
            {
                await newFile.CopyToAsync(stream); // Dosyayı kaydet
            }

            return newFileName; // Yeni dosyanın adını döndürüyoruz
        }
    }
}
