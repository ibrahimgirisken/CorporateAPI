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
        public UpdateBannerDTO UpdateBannerDTO{ get; set; }
    }
}
