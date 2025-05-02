using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Category
{
    public class CategoryTranslationDTO
    {
        public Guid LangId { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Brief { get; set; }
        public string? MetaDescription { get; set; }
    }
}
