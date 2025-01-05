using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Menu.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommandRequest, CreateMenuCommandResponse>
    {
        public Task<CreateMenuCommandResponse> Handle(CreateMenuCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
