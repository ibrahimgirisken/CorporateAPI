using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Banner
{
    public class BannerTranslationDTO
    {
        public Guid LangId { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
