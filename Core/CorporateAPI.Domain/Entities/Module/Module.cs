using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.Relationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities
{
    public class Module:BaseEntity
    {
        public Module()
        {
            Pages = new HashSet<Domain.Entities.Relationship.PageModule>();
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Config { get; set; }
        public ICollection<Domain.Entities.Relationship.PageModule>? Pages { get; set; }
    }
}
