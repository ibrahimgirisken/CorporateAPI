using CorporateAPI.Application.DTOs.Menu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Menu.CreateMenu
{
    public class CreateMenuCommandRequest:IRequest<CreateMenuCommandResponse>
    {
        public CreateMenuDTO MenuDto { get; set; }
    }
}
