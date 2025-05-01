using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Page
{
    public class ResultPageDTO
    {
        public string Id { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public string? ModuleIds { get; set; }
        public List<PageTranslationDTO> PageTranslations { get; set; }
    }
}
