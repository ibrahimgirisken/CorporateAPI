using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Menu
{
    public class ResultMenuDTO
    {
        public int Id { get; set; }
        public bool Vitrin { get; set; }
        public bool Footer { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public int? ParentId { get; set; }
        public List<ResultMenuDTO> Children { get; set; }
        public List<MenuTranslationDTO> MenuTranslations { get; set; }
    }
}
