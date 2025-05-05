using AutoMapper;
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

        public UpdateBannerCommandHandler(IBannerReadRepository bannerReadRepository, IBannerWriteRepository bannerWriteRepository, IMapper mapper)
        {
            _bannerReadRepository = bannerReadRepository;
            _bannerWriteRepository = bannerWriteRepository;
            _mapper = mapper;
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

            var existingTranslations = banner.BannerTranslations.ToList();


            foreach (var existingTranslation in existingTranslations)
            {
                if (!request.BannerTranslations.Any(t => t.LangCode == existingTranslation.Lang.LangCode))
                {
                    banner.BannerTranslations.Remove(existingTranslation);
                }
            }

            foreach (var translationDTO in request.BannerTranslations)
            {
                var translation = existingTranslations.FirstOrDefault(t => t.Lang.LangCode == translationDTO.LangCode);
                if (translation == null)
                {
                    translation = new BannerTranslation();
                    banner.BannerTranslations.Add(translation);
                }
                _mapper.Map(translationDTO, translation);
            }

            _bannerWriteRepository.Update(banner);
            await _bannerWriteRepository.SaveAsync();

            return new UpdateBannerCommandResponse();
        }
    }
}
