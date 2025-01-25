using AutoMapper;
using CorporateAPI.Application.Repositories.Setting;
using CorporateAPI.Domain.Entities.Setting;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Settting.CreateSetting
{
    public class CreateSettingCommandHandler : IRequestHandler<CreateSettingCommandRequest, CreateSettingCommandResponse>
    {
        readonly ISettingWriteRepository _settingWriteRepository;
        readonly IMapper _mapper;

        public CreateSettingCommandHandler(ISettingWriteRepository settingWriteRepository, IMapper mapper)
        {
            _settingWriteRepository = settingWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateSettingCommandResponse> Handle(CreateSettingCommandRequest request, CancellationToken cancellationToken)
        {
           var setting=_mapper.Map<Domain.Entities.Setting.Setting>(request);
            if (request.SettingTranslations!=null)
              {
                  setting.SettingTranslations=_mapper.Map<List<SettingTranslation>>(request.SettingTranslations);
              }
            await _settingWriteRepository.AddAsync(setting);
            await _settingWriteRepository.SaveAsync();
            return new();

        }
    }
}
