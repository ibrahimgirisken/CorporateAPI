using CorporateAPI.Application.Features.Commands.Menu.CreateMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Menu
{
    public class UpdateMenuDTO
    {
        public int Id { get; set; }
        public UpdateMenuDTO()
        {
            Children = new List<CreateMenuCommandRequest>();
            MenuTranslations = new List<MenuTranslationDTO>();
        }
        public bool Vitrin { get; set; }
        public bool Footer { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public List<CreateMenuCommandRequest> Children { get; set; }
        public List<MenuTranslationDTO> MenuTranslations { get; set; }
    }
}
