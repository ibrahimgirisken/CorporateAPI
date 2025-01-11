using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities
{
    public class Lang:BaseEntity
    {
        public string LangCode { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
