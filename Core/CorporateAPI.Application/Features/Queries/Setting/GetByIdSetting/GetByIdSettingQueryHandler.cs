using AutoMapper;
using CorporateAPI.Application.DTOs.Setting;
using CorporateAPI.Application.Repositories.Setting;
using MediatR;
using System.Linq.Expressions;

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
            var setting=_mapper.Map<Domain.Entities.Setting.Setting>(await _settingReadRepository.GetByIdAsync(request.Id,false,includes:new Expression<Func<Domain.Entities.Setting.Setting, object>>[]
            {
                e => e.SettingTranslations
            }, includeStrings: new[]
            {
                "SettingTranslations.Lang" }));

            var settingDto=_mapper.Map<ResultSettingDTO>(setting);
            return new()
            {
                Settings = settingDto
            };
        }
    }
}
