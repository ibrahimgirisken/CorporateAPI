using CorporateAPI.Application.DTOs.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Banner.GetAllBanner
{
    public class GetAllBannerQueryResponse
    {
        public List<ResultBannerDTO> Banners { get; set; }
    }
}
