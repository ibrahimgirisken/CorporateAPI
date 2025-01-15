using AutoMapper;
using CorporateAPI.Application.Repositories.Banner;
using CorporateAPI.Domain.Entities.Banner;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Banner.CreateBanner
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommandRequest, CreateBannerCommandResponse>
    {
        readonly IBannerWriteRepository _bannerWriteRepository;
        readonly IMapper _mapper;
        public CreateBannerCommandHandler(IBannerWriteRepository bannerWriteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bannerWriteRepository = bannerWriteRepository;
        }

        public async Task<CreateBannerCommandResponse> Handle(CreateBannerCommandRequest request, CancellationToken cancellationToken)
        {
            var banner=_mapper.Map<Domain.Entities.Banner.Banner>(request);
            var bannerTranslations = new HashSet<BannerTranslation>();
            if(request.BannerTranslations!=null)
            {
                foreach (var item in request.BannerTranslations)
                {
                    var translation = new BannerTranslation
                    {
                        Locale = item.Locale,
                        Content = item.Content,
                        Title = item.Title,
                        Url = item.Url,
                    };
                    bannerTranslations.Add(translation);
                }
                banner.BannerTranslations = bannerTranslations;
            }
            await _bannerWriteRepository.AddAsync(banner);
            await _bannerWriteRepository.SaveAsync();
            return new();
        }
    }
}
