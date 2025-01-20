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
        public List<BannerTranslation> BannerTranslations{ get; set; }
        public List<MenuTranslation>  MenuTranslations{ get; set; }
        public List<PageTranslation>PageTranslations{ get; set; }
        public List<ModuleTranslation> ModuleTranslations{ get; set; }
        public List<HomeTranslation> HomeTranslations{ get; set; }
    }
}
