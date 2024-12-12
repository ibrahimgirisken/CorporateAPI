using CorporateAPI.Application.DTOs.Module;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Module.UpdateModule
{
    public class UpdateModuleCommandRequest:IRequest<UpdateModuleCommandResponse>
    {
        public UpdateModuleDTO UpdateModule{ get; set; }
    }
}
