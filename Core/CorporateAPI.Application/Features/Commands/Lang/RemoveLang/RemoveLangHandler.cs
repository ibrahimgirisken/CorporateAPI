using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.RemoveLang
{
    public class RemoveLangHandler : IRequestHandler<RemoveLangRequest, RemoveLangResponse>
    {
        readonly ILangWriteRepository _langWriteRepository;

        public RemoveLangHandler(ILangWriteRepository langWriteRepository)
        {
            _langWriteRepository = langWriteRepository;
        }

        public async Task<RemoveLangResponse> Handle(RemoveLangRequest request, CancellationToken cancellationToken)
        {
            await _langWriteRepository.RemoveAsync(request.Id);
            await _langWriteRepository.SaveAsync();
            return new();
        }
    }
}
