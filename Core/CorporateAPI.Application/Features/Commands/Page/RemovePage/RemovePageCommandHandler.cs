using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.RemovePage
{
    public class RemovePageCommandHandler : IRequestHandler<RemovePageCommandRequest, RemovePageCommandResponse>
    {
        public Task<RemovePageCommandResponse> Handle(RemovePageCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
