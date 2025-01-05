using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.RemoveLang
{
    public class RemoveLangCommandHandler : IRequestHandler<RemoveLangCommandRequest, RemoveLangCommandResponse>
    {
        readonly ILangWriteRepository _langWriteRepository;

        public RemoveLangCommandHandler(ILangWriteRepository langWriteRepository)
        {
            _langWriteRepository = langWriteRepository;
        }

        public async Task<RemoveLangCommandResponse> Handle(RemoveLangCommandRequest request, CancellationToken cancellationToken)
        {
            await _langWriteRepository.RemoveAsync(request.Id);
            await _langWriteRepository.SaveAsync();
            return new();
        }
    }
}
