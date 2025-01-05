using CorporateAPI.Application.DTOs.Menu;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Menu.CreateMenu
{
    public class CreateMenuCommandRequest:IRequest<CreateMenuCommandResponse>
    {
        public CreateMenuDTO MenuDto { get; set; }
    }
}
