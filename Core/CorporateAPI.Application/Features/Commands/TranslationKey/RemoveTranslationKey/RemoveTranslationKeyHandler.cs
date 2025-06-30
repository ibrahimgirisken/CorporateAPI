using CorporateAPI.Application.Repositories.TranslationKey;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.TranslationKey.RemoveTranslationKey
{
    public class RemoveTranslationKeyHandler : IRequestHandler<RemoveTranslationKeyRequest, RemoveTranslationKeyResponse>
    {
        readonly ITranslationKeyWriteRepository _translationKeyWriteRepository;

        public RemoveTranslationKeyHandler(ITranslationKeyWriteRepository translationKeyWriteRepository)
        {
            _translationKeyWriteRepository = translationKeyWriteRepository;
        }

        public async Task<RemoveTranslationKeyResponse> Handle(RemoveTranslationKeyRequest request, CancellationToken cancellationToken)
        {
            await _translationKeyWriteRepository.RemoveAsync(request.Id);
            await _translationKeyWriteRepository.SaveAsync();
            return new();
        }
    }
}
