using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Page.GetByIdPage
{
    public class GetByIdPageQueryRequest:IRequest<GetByIdPageQueryResponse>
    {
        public int Id { get; set; }
    }
}
