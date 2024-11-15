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
        public string Title { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public Page Page { get; set; }
    }
}
