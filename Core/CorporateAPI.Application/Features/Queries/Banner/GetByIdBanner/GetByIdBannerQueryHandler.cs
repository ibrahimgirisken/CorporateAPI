using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.Repositories.Banner;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CorporateAPI.Application.Features.Queries.Banner.GetByIdBanner
{
    public class GetByIdBannerQueryHandler : IRequestHandler<GetByIdBannerQueryRequest, GetByIdBannerQueryResponse>
    {
        readonly IBannerReadRepository _bannerReadRepository;

        readonly IMapper _mapper;
        public GetByIdBannerQueryHandler(IBannerReadRepository bannerReadRepository, IMapper mapper)
        {
            _bannerReadRepository = bannerReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdBannerQueryResponse> Handle(GetByIdBannerQueryRequest request, CancellationToken cancellationToken)
        {
            ResultBannerDTO bannerDto = null;

            if (request.IncludeAllLanguages)
            {
                var banner = await _bannerReadRepository.GetByIdAsync(request.Id, false, includes: e => e.BannerTranslations);
                bannerDto = _mapper.Map<ResultBannerDTO>(banner);
            }
            else
            {
                var banner = await _bannerReadRepository.GetByIdAsync(
            request.Id,
            false,
            includes: e => e.BannerTranslations
                .Where(t => t.Lang.LangCode == request.Language));
                bannerDto = _mapper.Map<ResultBannerDTO>(banner);
            }

            return new()
            {
                Banner = bannerDto
            };
        }
    }
}
