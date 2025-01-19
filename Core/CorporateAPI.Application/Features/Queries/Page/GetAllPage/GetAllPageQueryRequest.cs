using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Page.GetAllPage
{
    public class GetAllPageQueryRequest:IRequest<GetAllPageQueryResponse>
    {
        public string? Language { get; set; }
        public bool IncludeAllLanguages { get; set; } = false;
    }
}
