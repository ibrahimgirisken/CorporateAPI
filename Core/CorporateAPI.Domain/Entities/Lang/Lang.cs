using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.Domain.Entities.Category;
using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.Datasheet;
using CorporateAPI.Domain.Entities.Home;
using CorporateAPI.Domain.Entities.Module;
using CorporateAPI.Domain.Entities.Product;
using CorporateAPI.Domain.Entities.Setting;
using CorporateAPI.Domain.Entities.Translation;

namespace CorporateAPI.Domain.Entities
{
    public class Lang:BaseEntity
    {
        public string LangCode { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public List<BannerTranslation> BannerTranslations{ get; set; }
        public List<PageTranslation> PageTranslations{ get; set; }
        public List<ModuleTranslation> ModuleTranslations{ get; set; }
        public List<HomeTranslation> HomeTranslations{ get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
        public List<DatasheetTranslation> DatasheetTranslations{ get; set; }
        public List<SettingTranslation>  SettingTranslations{ get; set; }
        public List<TranslationValue> Translations { get; set; }
    }
}
