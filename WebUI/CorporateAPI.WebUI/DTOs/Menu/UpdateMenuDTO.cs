using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Menu
{
    public class UpdateMenuDTO
    {
        public UpdateMenuDTO()
        {
            Children = new List<CreateMenuDTO>();
            MenuTranslations = new List<MenuTranslationDTO>();
        }
        public bool Vitrin { get; set; }
        public bool Footer { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public List<CreateMenuDTO> Children { get; set; }
        public List<MenuTranslationDTO> MenuTranslations { get; set; }
    }
}
