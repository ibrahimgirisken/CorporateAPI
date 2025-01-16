using AutoMapper;
using CorporateAPI.Application.Repositories.Banner;
using CorporateAPI.Domain.Entities.Banner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Banner.UpdateBanner
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommandRequest, UpdateBannerCommandResponse>
    {
        readonly IBannerReadRepository _bannerReadRepository;
        readonly IBannerWriteRepository _bannerWriteRepository;
        readonly IMapper _mapper;

        public UpdateBannerCommandHandler(IBannerReadRepository bannerReadRepository, IBannerWriteRepository bannerWriteRepository, IMapper mapper)
        {
            _bannerReadRepository = bannerReadRepository;
            _bannerWriteRepository = bannerWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBannerCommandResponse> Handle(UpdateBannerCommandRequest request, CancellationToken cancellationToken)
        {
            var banner =await _bannerReadRepository.GetByIdAsync(request.Id,false,includes:e=>e.BannerTranslations);
            foreach (var translsationDto in request.BannerTranslations)
            {
                var existingTranslation=banner.BannerTranslations.FirstOrDefault(t=>t.Locale== translsationDto.Locale);
                if (existingTranslation != null) 
                {
                    _mapper.Map(translsationDto, existingTranslation);
                }
                else
                {
                    var newTranslation=_mapper.Map<BannerTranslation>(translsationDto);
                    banner.BannerTranslations.Add(newTranslation);
                }
            }
            _bannerWriteRepository.Update(banner);
            await _bannerWriteRepository.SaveAsync();
            return new();

        }
    }
}
