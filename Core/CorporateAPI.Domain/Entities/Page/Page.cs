using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.Relationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities
{
    public class Page:BaseEntity
    {
        public Page()
        {
            Children=new HashSet<Page>();
            Modules = new HashSet<PageModule>();
        }
        public int? ParentId { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int Order { get; set; }
        public Page? Parent { get; set; }
        public ICollection<Page?> Children { get; set; }
        public ICollection<PageModule?> Modules { get; set; }
        public ICollection<PageTranslation> Translations { get; set; }
    }
}
