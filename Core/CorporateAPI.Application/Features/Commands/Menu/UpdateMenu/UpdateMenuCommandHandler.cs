using AutoMapper;
using CorporateAPI.Application.Repositories.Menu;
using CorporateAPI.Domain.Entities.Menu;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Menu.UpdateMenu
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommandRequest, UpdateMenuCommandResponse>
    {
        readonly IMenuWriteRepository _menuWriteRepository;
        readonly IMenuReadRepository _menuReadRepository;
        readonly IMapper _mapper;

        public UpdateMenuCommandHandler(IMenuWriteRepository menuWriteRepository, IMenuReadRepository menuReadRepository, IMapper mapper)
        {
            _menuWriteRepository = menuWriteRepository;
            _menuReadRepository = menuReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateMenuCommandResponse> Handle(UpdateMenuCommandRequest request, CancellationToken cancellationToken)
        {
           Domain.Entities.Menu.Menu menu =await _menuReadRepository.GetByIdAsync(request.Id,false,includes:e=>e.MenuTranslations);

            var menuData=_mapper.Map<Domain.Entities.Menu.Menu>(menu);
            
            var existingTranslations = menuData.MenuTranslations.ToList();  
            menu.MenuTranslations.Clear();
            foreach (var translationDTO in request.MenuDTO.MenuTranslations)
            {
                var translation=existingTranslations.FirstOrDefault(t => t.Locale == translationDTO.Locale) ?? new MenuTranslation();
                _mapper.Map(translationDTO, translation);  
                menuData.MenuTranslations.Add(translation);
            }
            _menuWriteRepository.Update(menuData);
            await _menuWriteRepository.SaveAsync();
            return new();

        }
    }
}
