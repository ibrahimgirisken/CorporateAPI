using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.TranslationKey.GetByIdTranslationKey
{
    public class GetByIdTranslationKeyHandler : IRequestHandler<GetByIdTranslationKeyRequest, GetByIdTranslationKeyResponse>
    {
        public Task<GetByIdTranslationKeyResponse> Handle(GetByIdTranslationKeyRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
