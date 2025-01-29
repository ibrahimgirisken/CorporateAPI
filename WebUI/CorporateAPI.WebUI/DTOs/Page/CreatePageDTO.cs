
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateAPI.WebUI.DTOs.Page
{
    public class CreatePageDTO
    {
         public CreatePageDTO()
        {
            PageTranslations = new List<PageTranslationDTO>();
        }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Video { get; set; }
        [NotMapped]
        public IFormFile? Image1File { get; set; }
        [NotMapped]
        public IFormFile? Image2File { get; set; }
        [NotMapped]
        public IFormFile? Image3File { get; set; }
        [NotMapped]
        public IFormFile? VideoFile { get; set; }
        public int Order { get; set; }= 0;
        public bool Status { get; set; }
        public string? ModuleIds { get; set; } = "0";
        public List<PageTranslationDTO> PageTranslations { get; set; }
    }
}
