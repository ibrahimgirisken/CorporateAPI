using CorporateAPI.Domain.Entities.Common;
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
            Modules = new HashSet<Domain.Entities.Relationship.PageModule>();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public ICollection<Domain.Entities.Relationship.PageModule>? Modules { get; set; }
    }
}
