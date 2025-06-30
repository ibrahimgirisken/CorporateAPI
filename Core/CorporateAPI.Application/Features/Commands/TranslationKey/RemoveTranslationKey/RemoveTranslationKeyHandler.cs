using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.TranslationKey.RemoveTranslationKey
{
    public class RemoveTranslationKeyHandler : IRequestHandler<RemoveTranslationKeyRequest, RemoveTranslationKeyResponse>
    {
        public Task<RemoveTranslationKeyResponse> Handle(RemoveTranslationKeyRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
