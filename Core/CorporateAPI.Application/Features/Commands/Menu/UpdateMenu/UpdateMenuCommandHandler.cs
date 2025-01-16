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
           var menu =await _menuReadRepository.GetByIdAsync(request.Id,false,includes:e=>e.MenuTranslations);
            foreach (var translsationDto in request.MenuTranslations)
            {
                var existingTranslation=menu.MenuTranslations.FirstOrDefault(t=>t.Locale==translsationDto.Locale);
                if (existingTranslation != null) 
                {
                    _mapper.Map(translsationDto, existingTranslation);
                }
                else
                {
                    var newTranslation=_mapper.Map<MenuTranslation>(translsationDto);
                    menu.MenuTranslations.Add(newTranslation);
                }
            }
            _menuWriteRepository.Update(menu);
            await _menuWriteRepository.SaveAsync();
            return new();

        }
    }
}
