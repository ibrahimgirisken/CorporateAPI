using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Menu
{
    public class UpdateMenuDTO
    {
        public UpdateMenuDTO()
        {
            Children = new HashSet<CreateMenuDTO>();
            MenuTranslations = new HashSet<MenuTranslationDTO>();
        }
        public bool Vitrin { get; set; }
        public bool Footer { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public ICollection<CreateMenuDTO> Children { get; set; }
        public ICollection<MenuTranslationDTO> MenuTranslations { get; set; }
    }
}
