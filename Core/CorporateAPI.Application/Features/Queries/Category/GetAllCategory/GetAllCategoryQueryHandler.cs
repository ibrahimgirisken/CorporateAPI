using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        public Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
