using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Page.GetByIdPage
{
    public class GetByIdPageQueryHandler : IRequestHandler<GetByIdPageQueryRequest, GetByIdPageQueryResponse>
    {
        public Task<GetByIdPageQueryResponse> Handle(GetByIdPageQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
