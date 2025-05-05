using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Home
{
    public class HomeTranslationDTO
    {
        public string LangCode { get; set; }
        public Guid LangId { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? AdditionalData { get; set; }
    }
}
