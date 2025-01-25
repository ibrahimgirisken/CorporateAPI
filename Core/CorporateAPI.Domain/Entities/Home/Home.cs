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
            HomeTranslations=new List<HomeTranslation>();
        }
        public string ContentType { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Video { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<HomeTranslation> HomeTranslations { get; set; }
    }
}
