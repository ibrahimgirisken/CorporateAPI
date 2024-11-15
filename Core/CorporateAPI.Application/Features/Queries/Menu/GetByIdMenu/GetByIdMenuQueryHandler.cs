using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Menu.GetByIdMenu
{
    public class GetByIdMenuQueryHandler : IRequestHandler<GetByIdMenuQueryRequest, GetByIdMenuQueryResponse>
    {
        public Task<GetByIdMenuQueryResponse> Handle(GetByIdMenuQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
