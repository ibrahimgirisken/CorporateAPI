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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Config { get; set; }
    }
}
