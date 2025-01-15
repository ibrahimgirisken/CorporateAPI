using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Home.UpdateHome
{
    public class UpdateHomeCommandHandler : IRequestHandler<UpdateHomeCommandRequest, UpdateHomeCommandResponse>
    {
        public Task<UpdateHomeCommandResponse> Handle(UpdateHomeCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
