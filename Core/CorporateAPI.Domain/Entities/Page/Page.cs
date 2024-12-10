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
            Children=new HashSet<Page>();
        }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public Page? Parent { get; set; }
        public ICollection<Page?> Children { get; set; }
    }
}
