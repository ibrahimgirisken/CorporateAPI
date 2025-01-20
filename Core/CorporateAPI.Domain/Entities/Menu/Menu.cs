using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities.Menu
{
    public class Menu:BaseEntity
    {
        public Menu()
        {
            Children = new List<Menu?>();
        }
        public bool Vitrin { get; set; } = true;
        public bool Footer { get; set; } = true;
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public Menu? Parent { get; set; }
        public List<Menu?> Children { get; set; }
        public List<MenuTranslation> MenuTranslations { get; set; }
    }
}
