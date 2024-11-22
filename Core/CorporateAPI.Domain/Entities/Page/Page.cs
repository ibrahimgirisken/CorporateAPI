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
            Menus=new HashSet<Menu>();
            Modules=new HashSet<Module>();
        }
        public string Content { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Domain.Entities.Module>  Modules { get; set; }
    }
}
