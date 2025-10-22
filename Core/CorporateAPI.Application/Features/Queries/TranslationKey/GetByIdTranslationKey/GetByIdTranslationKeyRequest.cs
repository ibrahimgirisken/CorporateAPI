using MediatR;

namespace CorporateAPI.Application.Features.Queries.TranslationKey.GetByIdTranslationKey
{
    public class GetByIdTranslationKeyRequest:IRequest<GetByIdTranslationKeyResponse>
    {
        public string Id { get; set; }
        public string? Language { get; set; }
        public bool IncludeAllLanguages { get; set; } = false;
    }
}
