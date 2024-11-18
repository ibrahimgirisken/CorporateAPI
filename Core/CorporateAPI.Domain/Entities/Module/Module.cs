using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Module
{
    public class Module:BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Config { get; set; }
        public ICollection<Page> Pages { get; set; }
    }
}
