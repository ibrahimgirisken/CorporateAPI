using CoreporateAPI.Infrastructure.Operations;
using CorporateAPI.WebUI.Abstract;

namespace CorporateAPI.WebUI.Concrete
{
    public class FileService : IFileService
    {
        public async Task<string> SaveFileAsync(IFormFile file, string uploadPath)
        {
            if (file != null && file.Length > 0)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);

                string sanitizedFileName = NameOperation.CharacterRegulatory(fileNameWithoutExtension);
                string newFileName = $"{sanitizedFileName}{extension}";

                 string filePath = Path.Combine(uploadPath, newFileName);

                int counter = 1;
                while (File.Exists(filePath))
                {
                    newFileName = $"{sanitizedFileName}-{counter}{extension}";
                    filePath = Path.Combine(uploadPath, newFileName);
                    counter++;
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return newFileName;
            }

            return null;
        }

        public async Task<string> UpdateFileAsync(IFormFile file, string existingFilePath, string uploadPath)
        {
            if (file == null)
            {
                return existingFilePath;
            }
            if (!string.IsNullOrEmpty(existingFilePath))
            {
                string oldFilePath = Path.Combine(uploadPath, existingFilePath);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            // Yeni dosyayı kaydet
            return await SaveFileAsync(file, uploadPath);
        }
    }
}
