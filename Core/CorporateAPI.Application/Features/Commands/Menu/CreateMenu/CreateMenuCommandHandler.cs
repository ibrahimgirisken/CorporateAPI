using AutoMapper;
using CorporateAPI.Application.Repositories.Menu;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Menu.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommandRequest, CreateMenuCommandResponse>
    {
        readonly IMenuWriteRepository _menuWriteRepository;

        readonly IMapper _mapper;
        public CreateMenuCommandHandler(IMenuWriteRepository menuWriteRepository, IMapper mapper)
        {
            _menuWriteRepository = menuWriteRepository;
            _mapper = mapper;
        }

        public Task<CreateMenuCommandResponse> Handle(CreateMenuCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
