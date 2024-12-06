using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Relationship
{
    public class PageModule
    {
        public Guid PageId { get; set; }
        public Guid ModuleId { get; set; }
        public Page Page { get; set; }
        public Module Module { get; set; }
    }
}
