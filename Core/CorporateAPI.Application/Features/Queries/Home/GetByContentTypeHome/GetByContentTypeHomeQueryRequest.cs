using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Home.GetByContentTypeHome
{
    public class GetByContentTypeHomeQueryRequest:IRequest<GetByContentTypeHomeQueryResponse>
    {

        public string ContentType { get; set; }
        public string? Language { get; set; }
    }
}
