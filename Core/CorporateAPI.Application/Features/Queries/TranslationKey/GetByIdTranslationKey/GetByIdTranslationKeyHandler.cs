using AutoMapper;
using CorporateAPI.Application.DTOs.Translation;
using CorporateAPI.Application.Repositories.TranslationKey;
using MediatR;
using System.Linq.Expressions;


namespace CorporateAPI.Application.Features.Queries.TranslationKey.GetByIdTranslationKey
{
    public class GetByIdTranslationKeyHandler : IRequestHandler<GetByIdTranslationKeyRequest, GetByIdTranslationKeyResponse>
    {
        readonly ITranslationKeyReadRepository _translationKeyReadRepository;
        readonly IMapper _mapper;

        public GetByIdTranslationKeyHandler(ITranslationKeyReadRepository translationKeyReadRepository, IMapper mapper)
        {
            _translationKeyReadRepository = translationKeyReadRepository;
            _mapper = mapper;
        }

        public Task<GetByIdTranslationKeyResponse> Handle(GetByIdTranslationKeyRequest request, CancellationToken cancellationToken)
        {
            ResultTranslationDTO translationDTO = null;

            if (request.IncludeAllLanguages)
            {
                var translation = _translationKeyReadRepository.GetByIdAsync(request.Id, false, includes: new Expression<Func<Domain.Entities.Translation.TranslationKey, object>>[]
                {
                    e => e.Translations
                }, includeStrings: new[]
                {
                    "TranslationKeys.Lang"
                }).Result;
                translationDTO = _mapper.Map<ResultTranslationDTO>(translation);
            }
            else
            {
                var translation = _translationKeyReadRepository.GetByIdAsync(
                    request.Id, false, includes: new Expression<Func<Domain.Entities.Translation.TranslationKey, object>>[]
                    {
                        e => e.Translations
                    }, includeStrings: new[]
                    {
                        "TranslationKeys.Lang"
                    }).Result;
                translation.Translations = translation.Translations
                    .Where(t => t.Lang.LangCode == request.Language)
                    .ToList();
                translationDTO = _mapper.Map<ResultTranslationDTO>(translation);
            }
            return Task.FromResult(new GetByIdTranslationKeyResponse
            {
                TranslationDTO = translationDTO
            });
        }
    }
}
