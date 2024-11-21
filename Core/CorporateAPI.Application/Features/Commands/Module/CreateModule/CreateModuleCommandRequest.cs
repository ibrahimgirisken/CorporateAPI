using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Module.CreateModule
{
    public class CreateModuleCommandRequest:IRequest<CreateModuleCommandResponse>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Config { get; set; }
    }
}
