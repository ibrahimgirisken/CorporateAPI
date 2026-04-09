using CorporateAPI.Application.DTOs.Banner;
using MediatR;

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
        public string? DesktopVideo { get; set; }
        public string? MobileVideo { get; set; }
        public int Order { get; set; } = 1;
        public bool Status { get; set; }
        public List<BannerTranslationDTO> BannerTranslations { get; set; }
    }
}
