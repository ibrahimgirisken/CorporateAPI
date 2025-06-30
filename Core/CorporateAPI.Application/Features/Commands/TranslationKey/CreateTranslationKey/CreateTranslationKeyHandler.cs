using AutoMapper;
using CorporateAPI.Application.Repositories.TranslationKey;
using CorporateAPI.Domain.Entities.Translation;
using MediatR;


namespace CorporateAPI.Application.Features.Commands.TranslationKey.CreateTranslationKey
{
    public class CreateTranslationKeyHandler : IRequestHandler<CreateTranslationKeyRequest, CreateTranslationKeyResponse>
    {
        readonly ITranslationKeyWriteRepository _translationKeyWriteRepository;
        readonly IMapper _mapper;

        public CreateTranslationKeyHandler(ITranslationKeyWriteRepository translationKeyWriteRepository, IMapper mapper)
        {
            _translationKeyWriteRepository = translationKeyWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateTranslationKeyResponse> Handle(CreateTranslationKeyRequest request, CancellationToken cancellationToken)
        {
            var translate=_mapper.Map<Domain.Entities.Translation.TranslationKey>(request);
            if(translate.Translations!=null)
            {
                translate.Translations=_mapper.Map<List<TranslationValue>>(request.Translations);
            }
            await _translationKeyWriteRepository.AddAsync(translate);
            await _translationKeyWriteRepository.SaveAsync();
            return new();
        }
    }
}
