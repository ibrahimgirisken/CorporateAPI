using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Module.RemoveModule
{
    public class RemoveModuleCommandRequest:IRequest<RemoveModuleCommandResponse>
    {
        public string Id { get; set; }
    }
}
