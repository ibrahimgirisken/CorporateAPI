using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Page.GetAllPage
{
    public class GetAllPageQueryHandler : IRequestHandler<GetAllPageQueryRequest, GetAllPageQueryResponse>
    {
        public Task<GetAllPageQueryResponse> Handle(GetAllPageQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
