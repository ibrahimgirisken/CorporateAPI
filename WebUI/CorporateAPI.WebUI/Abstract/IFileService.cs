namespace CorporateAPI.WebUI.Abstract
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string subDirectory);
        Task<bool> DeleteFileAsync(string fileName, string subDirectory);
        Task<string> UpdateFileAsync(string oldFileName, IFormFile newFile, string subDirectory);
    }
}
