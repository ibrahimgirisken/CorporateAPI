using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.UpdateLang
{
    public class UpdateLangHandler : IRequestHandler<UpdateLangRequest, UpdateLangResponse>
    {
        readonly ILangWriteRepository _langWriteRepository;

        public UpdateLangHandler(ILangWriteRepository langWriteRepository)
        {
            _langWriteRepository = langWriteRepository;
        }

        public async Task<UpdateLangResponse> Handle(UpdateLangRequest request, CancellationToken cancellationToken)
        {
            _langWriteRepository.Update(new Domain.Entities.Lang
            {
                Id = request.Id,
                LangCode = request.LangCode,
            });
            await _langWriteRepository.SaveAsync();
            return new();
        }
    }
}
