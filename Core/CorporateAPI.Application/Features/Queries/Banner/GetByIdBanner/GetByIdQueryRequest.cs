using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Banner.GetByIdBanner
{
    public class GetByIdQueryRequest:IRequest<GetByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
