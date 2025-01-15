using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Home.RemoveHome
{
    public class RemoveHomeCommandHandler : IRequestHandler<RemoveHomeCommandRequest, RemoveHomeCommandResponse>
    {
        public Task<RemoveHomeCommandResponse> Handle(RemoveHomeCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
