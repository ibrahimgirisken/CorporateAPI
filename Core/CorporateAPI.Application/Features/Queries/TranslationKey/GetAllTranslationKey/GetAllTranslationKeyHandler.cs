using AutoMapper;
using CorporateAPI.Application.DTOs.Translation;
using CorporateAPI.Application.Repositories.TranslationKey;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.TranslationKey.GetAllTranslationKey
{
    public class GetAllTranslationKeyHandler : IRequestHandler<GetAllTranslationKeyRequest, GetAllTranslationKeyResponse>
    {
        readonly ITranslationKeyReadRepository _translationKeyReadRepository;
        readonly IMapper _mapper;

        public GetAllTranslationKeyHandler(ITranslationKeyReadRepository translationKeyReadRepository, IMapper mapper)
        {
            _translationKeyReadRepository = translationKeyReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllTranslationKeyResponse> Handle(GetAllTranslationKeyRequest request, CancellationToken cancellationToken)
        {
           if(request.IncludeAllLanguages)
            {
                var translationKeys = _translationKeyReadRepository.GetAll(false).Include(e=>e.Translations).ThenInclude(l=>l.Lang).ToList();

                var translationKeyDtos = _mapper.Map<List<ResultTranslationDTO>>(translationKeys);
                return new()
                {
                   TranslationDTO = translationKeyDtos
                };
            }

           var language=request.Language ?? "en";
            var translateFiltered=_translationKeyReadRepository.GetAll(false)
                .Include(e => e.Translations)
                    .ThenInclude(t => t.Lang)
                .ToList();

            foreach (var translationKey in translateFiltered)
            {
                translationKey.Translations = translationKey.Translations
                    .Where(t => t.Lang.LangCode == language)
                    .ToList();
            }

            var filteredTranslationDtos = _mapper.Map<List<ResultTranslationDTO>>(translateFiltered);
            return new() { TranslationDTO = filteredTranslationDtos };
        }
    }
}
