using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.Repositories.Setting;
using CorporateAPI.Domain.Entities.Setting;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Settting.UpdateSetting
{
    public class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommandRequest, UpdateSettingCommandResponse>
    {
        readonly ISettingReadRepository settingReadRepository;
        readonly ISettingWriteRepository settingWriteRepository;
        readonly IMapper mapper;

        public UpdateSettingCommandHandler(ISettingReadRepository settingReadRepository, ISettingWriteRepository settingWriteRepository, IMapper mapper)
        {
            this.settingReadRepository = settingReadRepository;
            this.settingWriteRepository = settingWriteRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateSettingCommandResponse> Handle(UpdateSettingCommandRequest request, CancellationToken cancellationToken)
        {
            var setting =await settingReadRepository.GetByIdAsync(request.Id,false,e=>e.SettingTranslations);

            if (setting == null)
            {
                throw new Exception("Setting not found");
            }

            setting.WhiteLogo = request.WhiteLogo;
            setting.BlackLogo = request.BlackLogo;
            setting.Telephone = request.Telephone;
            setting.Email = request.Email;
            setting.Address = request.Address;
            setting.Facebook = request.Facebook;
            setting.Twitter = request.Twitter;
            setting.Instagram = request.Instagram;
            setting.LinkedIn = request.LinkedIn;
            setting.Youtube = request.Youtube;
            setting.GooglePlus = request.GooglePlus;
            setting.GoogleAnalytics = request.GoogleAnalytics;
            setting.GoogleRecaptcha = request.GoogleRecaptcha;
            setting.GoogleTagManager = request.GoogleTagManager;
            setting.GoogleSiteVerification = request.GoogleSiteVerification;
            setting.GoogleMaps = request.GoogleMaps;
            setting.Status = request.Status;

            var existingTranslations = setting.SettingTranslations.ToList();

            foreach (var existingTranslation in existingTranslations)
            {
               if(!request.SettingTranslations.Any(t=>t.Locale==existingTranslation.Locale))
                {
                    setting.SettingTranslations.Remove(existingTranslation);
                }
            }

            foreach (var translationDTO in request.SettingTranslations)
            {
                var translation = existingTranslations.FirstOrDefault(t => t.Locale == translationDTO.Locale);
                if (translation == null)
                {
                    translation = new SettingTranslation();
                    setting.SettingTranslations.Add(translation);
                }
                mapper.Map(translationDTO, translation);
            }
            
            settingWriteRepository.Update(setting);
            await settingWriteRepository.SaveAsync();

            return new UpdateSettingCommandResponse();
        }
    }
}
