using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Brand.RemoveBrand
{
    public class RemoveBrandCommandHandler : IRequestHandler<RemoveBrandCommandRequest, RemoveBrandCommandResponse>
    {
        public Task<RemoveBrandCommandResponse> Handle(RemoveBrandCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
