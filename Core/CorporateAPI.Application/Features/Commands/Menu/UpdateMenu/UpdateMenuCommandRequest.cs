using CorporateAPI.Application.DTOs.Menu;
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
        public UpdateMenuDTO MenuDTO { get; set; }
    }
}
