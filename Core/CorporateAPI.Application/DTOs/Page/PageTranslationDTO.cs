using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Page
{
    public class PageTranslationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Locale { get; set; }
    }
}
