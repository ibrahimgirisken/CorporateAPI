using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.Repositories.Banner;
using MediatR;

namespace CorporateAPI.Application.Features.Queries.Banner.GetByIdBanner
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQueryRequest, GetByIdQueryResponse>
    {
        readonly IBannerReadRepository _bannerReadRepository;

        readonly IMapper _mapper;
        public GetByIdQueryHandler(IBannerReadRepository bannerReadRepository, IMapper mapper)
        {
            _bannerReadRepository = bannerReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdQueryResponse> Handle(GetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var banner = await _bannerReadRepository.GetByIdAsync(request.Id, false, includes: e => e.BannerTranslations);
            var bannerDto=_mapper.Map<GetByIdBannerDTO>(banner);
            return new()
            {
                Banner = bannerDto
            };
        }
    }
}
