using CorporateAPI.Application.DTOs.Translation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.TranslationKey.UpdateTranslationKey
{
    public class UpdateTranslationKeyRequest:IRequest<UpdateTranslationKeyResponse>
    {
        public string Id { get; set; }
        public UpdateTranslationKeyRequest()
        {
            Translations = new List<TranslationValueDTO>();
        }
        public string Key { get; set; }
        public string? Description { get; set; }
        public List<TranslationValueDTO> Translations { get; set; }
    }
}
