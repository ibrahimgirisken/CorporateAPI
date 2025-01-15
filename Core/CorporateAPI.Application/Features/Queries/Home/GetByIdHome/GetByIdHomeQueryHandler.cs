using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Home.GetByIdHome
{
    public class GetByIdHomeQueryHandler : IRequestHandler<GetByIdHomeQueryRequest, GetByIdHomeQueryResponse>
    {
        public Task<GetByIdHomeQueryResponse> Handle(GetByIdHomeQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
