using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Menu
{
    public class MenuTranslationDTO
    {
        public string Locale { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
    }
}
