using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Module.GetByIdModule
{
    public class GetByIdModuleQueryHandler : IRequestHandler<GetByIdModuleQueryRequest, GetByIdModuleQueryResponse>
    {
        public Task<GetByIdModuleQueryResponse> Handle(GetByIdModuleQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
