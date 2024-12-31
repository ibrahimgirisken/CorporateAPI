using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.CreateLang
{
    public class CreateLangHandler : IRequestHandler<CreateLangRequest, CreateLangResponse>
    {
        readonly ILangWriteRepository _langWriteRepository;

        public CreateLangHandler(ILangWriteRepository langWriteRepository)
        {
            _langWriteRepository = langWriteRepository;
        }

        public async Task<CreateLangResponse> Handle(CreateLangRequest request, CancellationToken cancellationToken)
        {
           await _langWriteRepository.AddAsync(new Domain.Entities.Lang
            {
                LangCode=request.LangCode,
            });
           await _langWriteRepository.SaveAsync();
            return new();
        }
    }
}
