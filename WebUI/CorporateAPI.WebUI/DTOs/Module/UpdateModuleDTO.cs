using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Module
{
    public class UpdateModuleDTO
    {
        public UpdateModuleDTO()
        {
            ModuleTranslations = new List<ModuleTranslationDTO>();
        }
        public int Id { get; set; }
        public string ContentType { get; set; }
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
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<ModuleTranslationDTO> ModuleTranslations { get; set; }
    }
}
