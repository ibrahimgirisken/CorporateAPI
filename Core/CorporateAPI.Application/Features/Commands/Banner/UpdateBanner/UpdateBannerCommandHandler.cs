using AutoMapper;
using CorporateAPI.Application.Repositories.Banner;
using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.Domain.Entities.Category;
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
            var existingTranslations = banner.BannerTranslations.ToList();
            banner.Order = request.Order;
            banner.DesktopImage = request.DesktopImage;
            banner.TableteImage = request.TableteImage;
            banner.MobileImage = request.MobileImage;
            banner.Status=request.Status;
            _bannerWriteRepository.Update(banner);
            await _bannerWriteRepository.SaveAsync();
            return new();

        }
    }
}
