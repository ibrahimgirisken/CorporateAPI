using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Banner.GetByIdBanner
{
    public class GetByIdBannerQueryRequest:IRequest<GetByIdBannerQueryResponse>
    {
        public int Id { get; set; }
    }
}
