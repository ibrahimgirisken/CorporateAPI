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
        public CreateBannerDTO BannerDTO { get; set; }
    }
}
