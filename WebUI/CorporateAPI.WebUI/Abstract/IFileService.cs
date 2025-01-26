namespace CorporateAPI.WebUI.Abstract
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file, string folderName);
        Task DeleteFileAsync(string filePath);
        string GetFileUrl(string filePath);
    }
}
