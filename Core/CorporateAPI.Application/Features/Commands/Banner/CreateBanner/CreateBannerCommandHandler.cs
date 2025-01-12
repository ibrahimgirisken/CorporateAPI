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
            _bannerWriteRepository = bannerWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateBannerCommandResponse> Handle(CreateBannerCommandRequest request, CancellationToken cancellationToken)
        {
            var banner=_mapper.Map<Domain.Entities.Banner.Banner>(request);
            var bannerTranslations = new HashSet<Domain.Entities.Banner.BannerTranslation>();
            if(request.Translations!=null)
            {
                foreach (var item in request.Translations)
                {
                    var translation = new BannerTranslation
                    {
                        Content = item.Content,
                        Locale = item.Locale,
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
