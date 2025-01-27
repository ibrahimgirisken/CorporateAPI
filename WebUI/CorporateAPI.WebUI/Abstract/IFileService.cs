namespace CorporateAPI.WebUI.Abstract
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string uploadPath);
        Task<string> UpdateFileAsync(IFormFile file, string existingFilePath, string uploadPath);
    }
}
