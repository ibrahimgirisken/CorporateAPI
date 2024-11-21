using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Module.GetAllModule
{
    public class GetAllModuleQueryHandler : IRequestHandler<GetAllModuleQueryRequest, GetAllModuleQueryResponse>
    {
        public Task<GetAllModuleQueryResponse> Handle(GetAllModuleQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
