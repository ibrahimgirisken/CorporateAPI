using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Lang.GetByIdLang
{
    public class GetByIdLangHandler : IRequestHandler<GetByIdLangRequest, GetByIdLangResponse>
    {
        public Task<GetByIdLangResponse> Handle(GetByIdLangRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
