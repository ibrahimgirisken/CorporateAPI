using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Page.GetByUrlAddressPage
{
    public class GetByUrlAddressPageQueryRequest:IRequest<GetByUrlAddressPageQueryResponse>
    {
        public string? UrlAddress { get; set; }
    }
}
