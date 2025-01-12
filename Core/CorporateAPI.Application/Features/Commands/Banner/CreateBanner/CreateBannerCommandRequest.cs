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
            BannerTranslations = new HashSet<BannerTranslationDTO>();
        }
        public string? DesktopImage { get; set; }
        public string? TableteImage { get; set; }
        public string? MobileImage { get; set; }
        public int Order { get; set; } = 1;
        public bool IsDeleted { get; set; } = false;
        public ICollection<BannerTranslationDTO> BannerTranslations { get; set; }
    }
}
