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
            MenuTranslations = new List<MenuTranslationDTO>();
        }
        public bool Vitrin { get; set; }
        public bool Footer { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public int? ParentId { get; set; }
        public List<MenuTranslationDTO> MenuTranslations { get; set; }
    }
}
