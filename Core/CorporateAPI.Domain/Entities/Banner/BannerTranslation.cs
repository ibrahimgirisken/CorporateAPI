using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Banner
{
    public class BannerTranslation:BaseEntity
    {
        public string Locale { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int BannerId { get; set; }
        public Banner Banner { get; set; }
    }
}
