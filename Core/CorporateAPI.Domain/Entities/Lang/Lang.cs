using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.Home;
using CorporateAPI.Domain.Entities.Menu;
using CorporateAPI.Domain.Entities.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities
{
    public class Lang:BaseEntity
    {
        public string LangCode { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<BannerTranslation> BannerTranslations{ get; set; }
        public ICollection<MenuTranslation>  MenuTranslations{ get; set; }
        public ICollection<PageTranslation>PageTranslations{ get; set; }
        public ICollection<ModuleTranslation> ModuleTranslations{ get; set; }
        public ICollection<HomeTranslation> HomeTranslations{ get; set; }
    }
}
