using CorporateAPI.Application.DTOs.Banner;

namespace CorporateAPI.Application.Features.Queries.Banner.GetAllBanner
{
    public class GetAllBannerQueryResponse
    {
        public List<ResultBannerDTO> Banners { get; set; }
    }
}
