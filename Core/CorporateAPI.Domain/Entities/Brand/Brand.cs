using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Brand
{
    public class Brand:BaseEntity
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }=false;
    }
}
