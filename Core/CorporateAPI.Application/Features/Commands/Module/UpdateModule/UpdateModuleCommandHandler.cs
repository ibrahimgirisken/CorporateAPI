using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Module.UpdateModule
{
    public class UpdateModuleCommandHandler : IRequestHandler<UpdateModuleCommandRequest, UpdateModuleCommandResponse>
    {
        public Task<UpdateModuleCommandResponse> Handle(UpdateModuleCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
