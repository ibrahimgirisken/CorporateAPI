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
            var banner = await _bannerReadRepository.GetByIdAsync(request.Id, false, includes: e => e.BannerTranslations);
            var bannerDto=_mapper.Map<ResultBannerDTO>(banner);
            return new()
            {
                Banner = bannerDto
            };
        }
    }
}
