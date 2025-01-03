using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Page
{
    public class GetPageDTO
    {
        public int Id { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int Order { get; set; }
        public string? ModuleIds { get; set; }
        public ICollection<PageTranslation> PageTranslations { get; set; }

    }
}
