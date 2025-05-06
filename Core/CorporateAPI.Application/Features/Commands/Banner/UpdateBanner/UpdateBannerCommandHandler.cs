using AutoMapper;
using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Application.Helpers;
using CorporateAPI.Application.Repositories.Banner;
using CorporateAPI.Domain.Entities.Banner;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Banner.UpdateBanner
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommandRequest, UpdateBannerCommandResponse>
    {
        readonly IBannerReadRepository _bannerReadRepository;
        readonly IBannerWriteRepository _bannerWriteRepository;
        readonly IMapper _mapper;
        readonly ILanguageCodeResolverService _langService;

        public UpdateBannerCommandHandler(IBannerReadRepository bannerReadRepository, IBannerWriteRepository bannerWriteRepository, IMapper mapper, ILanguageCodeResolverService langService = null)
        {
            _bannerReadRepository = bannerReadRepository;
            _bannerWriteRepository = bannerWriteRepository;
            _mapper = mapper;
            _langService = langService;
        }

        public async Task<UpdateBannerCommandResponse> Handle(UpdateBannerCommandRequest request, CancellationToken cancellationToken)
        {
            var banner = await _bannerReadRepository.GetByIdAsync(request.Id, false, includes: e => e.BannerTranslations);

            if (banner == null)
                throw new Exception("Banner not found!");

            banner.Order = request.Order;
            banner.DesktopImage = request.DesktopImage;
            banner.TableteImage = request.TableteImage;
            banner.MobileImage = request.MobileImage;
            banner.DesktopVideo = request.DesktopVideo;
            banner.MobileVideo = request.MobileVideo;
            banner.Status = request.Status;

            TranslationHelper.UpdateOrAddTranslations(
         banner.BannerTranslations,
         request.BannerTranslations,
         dto => dto.LangCode,
         code => _langService.GetLangIdByLangCode(code),
         (dto, entity) => _mapper.Map(dto, entity)
     );

            _bannerWriteRepository.Update(banner);
            await _bannerWriteRepository.SaveAsync();

            return new UpdateBannerCommandResponse();
        }
    }
}
