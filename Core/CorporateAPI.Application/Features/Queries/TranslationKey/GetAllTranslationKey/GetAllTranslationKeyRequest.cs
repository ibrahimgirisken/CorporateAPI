using MediatR;

namespace CorporateAPI.Application.Features.Queries.TranslationKey.GetAllTranslationKey
{
    public class GetAllTranslationKeyRequest:IRequest<GetAllTranslationKeyResponse>
    {
        public string? Language { get; set; }
        public bool IncludeAllLanguages { get; set; } = false;
    }
}
