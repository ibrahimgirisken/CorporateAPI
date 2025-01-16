using CorporateAPI.Application.DTOs.Menu;
using CorporateAPI.Application.Features.Commands.Menu.CreateMenu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Menu.UpdateMenu
{
    public class UpdateMenuCommandRequest:IRequest<UpdateMenuCommandResponse>
    {
        public int Id { get; set; }
        public UpdateMenuCommandRequest()
        {
            Children = new HashSet<CreateMenuCommandRequest>();
            MenuTranslations = new HashSet<MenuTranslationDTO>();
        }
        public bool Vitrin { get; set; }
        public bool Footer { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public ICollection<CreateMenuCommandRequest> Children { get; set; }
        public ICollection<MenuTranslationDTO> MenuTranslations { get; set; }
    }
}
