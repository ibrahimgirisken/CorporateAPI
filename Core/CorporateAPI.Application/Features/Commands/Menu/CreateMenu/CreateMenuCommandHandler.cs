using AutoMapper;
using CorporateAPI.Application.Repositories.Menu;
using CorporateAPI.Domain.Entities.Menu;
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

        public async Task<CreateMenuCommandResponse> Handle(CreateMenuCommandRequest request, CancellationToken cancellationToken)
        {
            var menu = _mapper.Map<Domain.Entities.Menu.Menu>(request);
            if (request.MenuTranslations != null)
            {
                menu.MenuTranslations=_mapper.Map<List<MenuTranslation>>(request.MenuTranslations);
            }
            await _menuWriteRepository.AddAsync(menu);
            await _menuWriteRepository.SaveAsync();
            return new();
        }
    }
}
