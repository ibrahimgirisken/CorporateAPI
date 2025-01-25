using CorporateAPI.Application.DTOs.Menu;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Menu.CreateMenu
{
    public class CreateMenuCommandRequest : IRequest<CreateMenuCommandResponse>
    {
        public CreateMenuCommandRequest()
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
