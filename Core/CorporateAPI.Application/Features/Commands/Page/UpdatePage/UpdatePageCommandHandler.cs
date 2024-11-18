using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.UpdatePage
{
    public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommandRequest, UpdatePageCommandResponse>
    {
        public Task<UpdatePageCommandResponse> Handle(UpdatePageCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
