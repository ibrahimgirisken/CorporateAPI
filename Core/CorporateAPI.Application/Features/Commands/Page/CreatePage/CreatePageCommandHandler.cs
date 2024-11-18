using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.CreatePage
{
    public class CreatePageCommandHandler : IRequestHandler<CreatePageCommandRequest, CreatePageCommandResponse>
    {
        public Task<CreatePageCommandResponse> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
