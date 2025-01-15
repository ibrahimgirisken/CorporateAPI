using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Home.CreateHome
{
    public class CreateHomeCommandHandler : IRequestHandler<CreateHomeCommandRequest, CreateHomeCommandResponse>
    {
        public Task<CreateHomeCommandResponse> Handle(CreateHomeCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
