using CorporateAPI.Domain.Entities.Translation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.TranslationKey.CreateTranslationKey
{
    public class CreateTranslationKeyRequest:IRequest<CreateTranslationKeyResponse>
    {
        public CreateTranslationKeyRequest()
        {
            Translations = new List<TranslationValue>();
        }
        public string Key { get; set; }
        public string? Description { get; set; }
        public List<TranslationValue> Translations{ get; set; }
    }
}
