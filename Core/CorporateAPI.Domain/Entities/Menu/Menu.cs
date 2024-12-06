using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities
{
    public class Menu:BaseEntity
    {
        public Menu()
        {
            Children =new HashSet<Menu>();
        }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Priority { get; set; }
        public int? ParentId { get; set; }
        public Menu? Parent { get; set; }
        public int? PageId { get; set; }
        public Page? Page { get; set; }
        public ICollection<Menu>? Children { get; set; }
    }
}
