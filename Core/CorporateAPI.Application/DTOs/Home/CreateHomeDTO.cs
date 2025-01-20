using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Home
{
    public class CreateHomeDTO
    {
        public CreateHomeDTO()
        {
            HomeTranslations=new List<HomeTranslationDTO>();
        }
        public int Id { get; set; }
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<HomeTranslationDTO> HomeTranslations { get; set; }
    }
}
