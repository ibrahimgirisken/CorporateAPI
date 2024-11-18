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
            Modules = new HashSet<Domain.Entities.Module.Module>();
        }
        public Guid MenuId { get; set; }
        public string Content { get; set; }
        public Menu Menu { get; set; }
        public ICollection<Domain.Entities.Module.Module>  Modules { get; set; }
    }
}
