using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.TranslationKey.CreateTranslationKey
{
    public class CreateTranslationKeyHandler : IRequestHandler<CreateTranslationKeyRequest, CreateTranslationKeyResponse>
    {
        public Task<CreateTranslationKeyResponse> Handle(CreateTranslationKeyRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
