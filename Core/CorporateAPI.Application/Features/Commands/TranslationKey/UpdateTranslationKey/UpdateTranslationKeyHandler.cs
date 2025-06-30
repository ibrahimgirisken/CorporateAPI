using AutoMapper;
using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Application.Helpers;
using CorporateAPI.Application.Repositories.TranslationKey;
using MediatR;
using System.Linq.Expressions;

namespace CorporateAPI.Application.Features.Commands.TranslationKey.UpdateTranslationKey
{
    public class UpdateTranslationKeyHandler : IRequestHandler<UpdateTranslationKeyRequest, UpdateTranslationKeyResponse>
    {
        readonly ITranslationKeyWriteRepository _translationKeyWriteRepository;
        readonly ITranslationKeyReadRepository _translationKeyReadRepository;
        readonly IMapper _mapper;
        readonly ILanguageCodeResolverService _langService;

        public UpdateTranslationKeyHandler(ITranslationKeyWriteRepository translationKeyWriteRepository, ITranslationKeyReadRepository translationKeyReadRepository, IMapper mapper, ILanguageCodeResolverService langService)
        {
            _translationKeyWriteRepository = translationKeyWriteRepository;
            _translationKeyReadRepository = translationKeyReadRepository;
            _mapper = mapper;
            _langService = langService;
        }

        public async Task<UpdateTranslationKeyResponse> Handle(UpdateTranslationKeyRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Translation.TranslationKey translation = await _translationKeyReadRepository.GetByIdAsync(request.Id, false, includes: new Expression<Func<Domain.Entities.Translation.TranslationKey,object>>[]
            {
                e=>e.Translations
            });

            if (translation == null)
                throw new Exception("Translation key not found!");

            translation.Key = request.Key;
            translation.Description = request.Description;

            TranslationHelper.UpdateOrAddTranslations(
                translation.Translations,
                 request.Translations,
                 dto => dto.LangCode,
                 code => _langService.GetLangIdByLangCode(code),
                 (dto, entity) => _mapper.Map(dto, entity));

            _translationKeyWriteRepository.Update(translation);
            await _translationKeyWriteRepository.SaveAsync();
            return new UpdateTranslationKeyResponse();
        }
    }
}
