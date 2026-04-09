using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.Repositories.Banner;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CorporateAPI.Application.Features.Queries.Banner.GetAllBanner
{
    public class GetAllBannerQueryHandler : IRequestHandler<GetAllBannerQueryRequest, GetAllBannerQueryResponse>
    {
        readonly IBannerReadRepository _bannerReadRepository;
        readonly IMapper _mapper;

        public GetAllBannerQueryHandler(IBannerReadRepository bannerReadRepository, IMapper mapper)
        {
            _bannerReadRepository = bannerReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllBannerQueryResponse> Handle(GetAllBannerQueryRequest request, CancellationToken cancellationToken)
        {


                var bannerTranslations =_bannerReadRepository.GetAll(false).Include(e => e.BannerTranslations).ThenInclude(l=>l.Lang).ToList();
                var bannerDatas = _mapper.Map<List<ResultBannerDTO>>(bannerTranslations);
                return new()
                {
                    Banners = bannerDatas
                };
        }
    }
}
