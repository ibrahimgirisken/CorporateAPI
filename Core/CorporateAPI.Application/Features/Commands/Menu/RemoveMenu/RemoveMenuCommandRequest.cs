using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Menu.RemoveMenu
{
    public class RemoveMenuCommandRequest:IRequest<RemoveMenuCommandResponse>
    {
        public int Id { get; set; }
    }
}
