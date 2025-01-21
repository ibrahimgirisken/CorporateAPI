using CorporateAPI.Domain.Entities.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Home
{
    public class UpdateHomeDTO
    {
        public int Id { get; set; }
        public UpdateHomeDTO()
        {
            HomeTranslations = new List<HomeTranslation>();
        }
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<HomeTranslation> HomeTranslations { get; set; }
    }
}
