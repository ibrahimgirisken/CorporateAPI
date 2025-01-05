using MediatR;

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
