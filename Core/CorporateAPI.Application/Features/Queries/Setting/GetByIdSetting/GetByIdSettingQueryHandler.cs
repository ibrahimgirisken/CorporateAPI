using AutoMapper;
using CorporateAPI.Application.DTOs.Setting;
using CorporateAPI.Application.Repositories.Setting;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CorporateAPI.Application.Features.Queries.Setting.GetByIdSetting
{
    public class GetByIdSettingQueryHandler : IRequestHandler<GetByIdSettingQueryRequest, GetByIdSettingQueryResponse>
    {
        readonly ISettingReadRepository _settingReadRepository;
        readonly IMapper _mapper;

        public GetByIdSettingQueryHandler(ISettingReadRepository settingReadRepository, IMapper mapper)
        {
            _settingReadRepository = settingReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdSettingQueryResponse> Handle(GetByIdSettingQueryRequest request, CancellationToken cancellationToken)
        {


            if (request.IncludeAllLanguages)
            {
                var settingTranslations = _settingReadRepository.GetAll(false).Include(e => e.SettingTranslations).ToList();
                var settingDatas = _mapper.Map<List<ResultSettingDTO>>(settingTranslations);
                return new()
                {
                    Settings = settingDatas
                };
            }
            var language = request.Language ?? "en";
            var settingsFiltered = _settingReadRepository.GetAll(false)
                   .Include(e => e.SettingTranslations)
                       .ThenInclude(t => t.Lang)
                   .ToList();
            foreach (var setting in settingsFiltered)
            {
                setting.SettingTranslations = setting.SettingTranslations
                    .Where(t => t.Lang.LangCode == language)
                    .ToList();
            }

            var filteredSettingDtos = _mapper.Map<List<ResultSettingDTO>>(settingsFiltered);
            return new() { Settings = filteredSettingDtos };

        }
    }
}
