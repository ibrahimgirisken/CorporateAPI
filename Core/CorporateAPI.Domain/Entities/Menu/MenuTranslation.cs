using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Menu
{
    public class MenuTranslation:BaseEntity
    {
        public string Locale { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
