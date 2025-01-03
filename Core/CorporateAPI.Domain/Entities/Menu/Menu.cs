using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities.Menu
{
    public class Menu:BaseEntity
    {
        public Menu()
        {
            Children = new HashSet<Menu>();
        }
        public bool Vitrin { get; set; } = true;
        public bool Footer { get; set; } = true;
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public Menu? Parent { get; set; }
        public ICollection<Menu?> Children { get; set; }
        public ICollection<MenuTranslation> MenuTranslations { get; set; }
    }
}
