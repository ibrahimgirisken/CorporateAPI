using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Category
{
    public class CategoryTranslation
    {
        public string Locale { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Brief { get; set; }
        public string? MetaDescription { get; set; }
    }
}
