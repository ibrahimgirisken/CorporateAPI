using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.MenuEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.PageEntity
{
    public class Page:BaseEntity
    {
        public Guid MenuId { get; set; }
        public string Content { get; set; }
        public Menu Menu { get; set; }
    }
}
