using AutoMapper;
using CorporateAPI.Application.Repositories.Banner;
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
            var banner =await _bannerReadRepository.GetByIdAsync(request.UpdateBannerDTO.Id,false,includes:e=>e.BannerTranslations);
            var existingTranslations=banner.BannerTranslations.ToList();
            var bannerData = _mapper.Map<Domain.Entities.Banner.Banner>(banner);
            banner.BannerTranslations.Clear();
            foreach (var translationDto in existingTranslations)
            {
                var translation=existingTranslations.FirstOrDefault(t=>t.Locale==translationDto.Locale)?? new Domain.Entities.Banner.BannerTranslation();
            }
            _bannerWriteRepository.Update(banner);
            await _bannerWriteRepository.SaveAsync();
            return new();

        }
    }
}
