using CorporateAPI.Application.DTOs.Translation;

namespace CorporateAPI.Application.Features.Queries.TranslationKey.GetAllTranslationKey
{
    public class GetAllTranslationKeyResponse
    {
        public List<ResultTranslationDTO> TranslationDTO{ get; set; }
    }
}
