using CorporateAPI.Domain.Entities.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Home
{
    public class UpdateHomeDTO
    {
        public int Id { get; set; }
        public UpdateHomeDTO()
        {
            HomeTranslations = new List<HomeTranslationDTO>();
        }
        public string ContentType { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public string? Video { get; set; }
        [NotMapped]
        public IFormFile? Image1File { get; set; }
        [NotMapped]
        public IFormFile? Image2File { get; set; }
        [NotMapped]
        public IFormFile? Image3File { get; set; }
        [NotMapped]
        public IFormFile? Image4File { get; set; }
        [NotMapped]
        public IFormFile? Image5File { get; set; }
        [NotMapped]
        public IFormFile? VideoFile { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<HomeTranslationDTO> HomeTranslations { get; set; }
    }
}
