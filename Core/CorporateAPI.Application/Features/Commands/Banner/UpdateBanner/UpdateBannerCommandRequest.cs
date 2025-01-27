using CorporateAPI.Application.DTOs.Banner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Banner.UpdateBanner
{
    public class UpdateBannerCommandRequest:IRequest<UpdateBannerCommandResponse>
    {
        public int Id { get; set; }
        public UpdateBannerCommandRequest()
        {
            BannerTranslations = new List<BannerTranslationDTO>();
        }
        public string? DesktopImage { get; set; }
        public string? TableteImage { get; set; }
        public string? MobileImage { get; set; }
        public string? DesktopVideo { get; set; }
        public string? MobileVideo { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<BannerTranslationDTO> BannerTranslations { get; set; }
    }
}
