using CorporateAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Relationship
{
    public class PageModule
    {
        public int PageId { get; set; }
        public int ModuleId { get; set; }
        public int Order { get; set; }
        public virtual Module Module { get; set; }
        public virtual Page Page { get; set; }
    }
}