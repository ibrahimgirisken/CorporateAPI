using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Brand.GetByIdBrand
{
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQueryRequest, GetByIdBrandQueryResponse>
    {
        public Task<GetByIdBrandQueryResponse> Handle(GetByIdBrandQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
