using CorporateAPI.Application.DTOs.Banner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Banner.CreateBanner
{
    public class CreateBannerCommandRequest:IRequest<CreateBannerCommandResponse>
    {
        public CreateBannerCommandRequest()
        {
            BannerTranslations = new List<BannerTranslationDTO>();
        }
        public string? DesktopImage { get; set; }
        public string? TableteImage { get; set; }
        public string? MobileImage { get; set; }
        public int Order { get; set; } = 1;
        public bool Status { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<BannerTranslationDTO> BannerTranslations { get; set; }
    }
}
