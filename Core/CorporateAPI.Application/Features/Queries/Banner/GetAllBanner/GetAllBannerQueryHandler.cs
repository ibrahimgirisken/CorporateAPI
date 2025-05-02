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

            if (request.IncludeAllLanguages)
            {
                var bannerTranslations = _bannerReadRepository.GetAll(false).Include(e => e.BannerTranslations).ToList();
                var bannerDatas = _mapper.Map<List<ResultBannerDTO>>(bannerTranslations);
                return new()
                {
                    Banners = bannerDatas
                };
            }
            var language = request.Language ?? "en";
            var bannersFiltered = _bannerReadRepository.GetAll(false).Where(b => !b.IsDeleted)
                   .Include(e => e.BannerTranslations)
                       .ThenInclude(t => t.Lang)
                   .ToList();
            foreach (var banner in bannersFiltered)
            {
                banner.BannerTranslations = banner.BannerTranslations
                    .Where(t => t.Lang.LangCode == language)
                    .ToList();
            }

            var filteredBannerDtos = _mapper.Map<List<ResultBannerDTO>>(bannersFiltered);
            return new() { Banners = filteredBannerDtos };

        }
    }
}
