using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Lang
{
    public class UpdateLangDTO
    {
        public int Id { get; set; }
        public string LangCode { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
