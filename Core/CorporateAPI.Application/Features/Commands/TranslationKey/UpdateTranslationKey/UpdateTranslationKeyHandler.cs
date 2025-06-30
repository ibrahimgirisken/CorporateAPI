using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.TranslationKey.UpdateTranslationKey
{
    public class UpdateTranslationKeyHandler : IRequestHandler<UpdateTranslationKeyRequest, UpdateTranslationKeyResponse>
    {
        public Task<UpdateTranslationKeyResponse> Handle(UpdateTranslationKeyRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
