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
            Domain.Entities.Menu.Menu menu = await _menuReadRepository.GetByIdAsync(request.Id, false, includes: e => e.MenuTranslations);
            
            if (menu == null)
                throw new Exception("Menu not found!");

            menu.Order = request.Order;
            menu.Status = request.Status;
            menu.ParentId = request.ParentId;
            
            var existingTranslations = menu.MenuTranslations.ToList();

            foreach (var existingTranslation in existingTranslations)
            {
                if (!request.MenuTranslations.Any(t => t.Locale == existingTranslation.Locale))
                {
                    menu.MenuTranslations.Remove(existingTranslation);
                }
            }

            foreach (var translationDTO in request.MenuTranslations)
            {
                var translation = existingTranslations.FirstOrDefault(t => t.Locale == translationDTO.Locale);
                if (translation == null)
                {
                    translation = new MenuTranslation();
                    menu.MenuTranslations.Add(translation);
                }
                _mapper.Map(translationDTO, translation);
            }

            _menuWriteRepository.Update(menu);
            await _menuWriteRepository.SaveAsync();

            return new UpdateMenuCommandResponse();

        }
    }
}
