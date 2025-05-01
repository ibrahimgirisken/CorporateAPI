using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.Repositories.Banner;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var menus = _bannerReadRepository.GetAll(false).Include(e => e.BannerTranslations.Where(l => l.Locale == language)).ToList();
            var bannerData = _mapper.Map<List<ResultBannerDTO>>(menus);
            return new()
            {
                Banners = bannerData
            };

        }
    }
}
