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
            var banners=_bannerReadRepository.GetAll(false).Include(m=>m.BannerTranslations).ToList();
            var bannerDtos=_mapper.Map<List<ResultBannerDTO>>(banners);
            return new()
            {
                Banners = bannerDtos
            };
        }
    }
}
