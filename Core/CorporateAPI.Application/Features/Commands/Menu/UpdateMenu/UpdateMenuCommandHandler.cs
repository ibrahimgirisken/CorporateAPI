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
            var menu = await _menuReadRepository.GetByIdAsync(request.Id, false, includes: e => e.MenuTranslations);
            _mapper.Map(request, menu);

            // Mevcut translation'ları güncelle veya ekle
            foreach (var translationDto in request.MenuTranslations)
            {
                var existingTranslation = menu.MenuTranslations
                                              .FirstOrDefault(t => t.Locale == translationDto.Locale);

                if (existingTranslation != null)
                {
                    // Var olanı güncelle
                    _mapper.Map(translationDto, existingTranslation);
                }
                else
                {
                    // Yeni bir translation ekle
                    menu.MenuTranslations.Add(_mapper.Map<MenuTranslation>(translationDto));
                }
            }

            // Veritabanından silinmesi gereken eski translation'ları çıkar
            var toRemoveTranslations = menu.MenuTranslations
                                           .Where(mt => !request.MenuTranslations
                                                          .Any(rt => rt.Locale == mt.Locale))
                                           .ToList();

            foreach (var translation in toRemoveTranslations)
            {
                menu.MenuTranslations.Remove(translation);
            }

            _menuWriteRepository.Update(menu);
            await _menuWriteRepository.SaveAsync();
            return new();

        }
    }
}
