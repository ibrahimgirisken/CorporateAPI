using CorporateAPI.Application.DTOs.Translation;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.TranslationKey.CreateTranslationKey
{
    public class CreateTranslationKeyRequest:IRequest<CreateTranslationKeyResponse>
    {
        public CreateTranslationKeyRequest()
        {
            Translations = new List<TranslationValueDTO>();
        }
        public string Key { get; set; }
        public string? Description { get; set; }
        public List<TranslationValueDTO> Translations{ get; set; }
    }
}
