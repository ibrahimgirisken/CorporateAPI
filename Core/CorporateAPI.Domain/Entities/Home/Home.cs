using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Home
{
    public class Home:BaseEntity
    {
        public Home()
        {
            HomeTranslations=new HashSet<HomeTranslation>();
        }
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<HomeTranslation> HomeTranslations { get; set; }
    }
}
