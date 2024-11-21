using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Module.RemoveModule
{
    public class RemoveModuleCommandHandler : IRequestHandler<RemoveModuleCommandRequest, RemoveModuleCommandResponse>
    {
        readonly IModuleWriteRepository _moduleWriteRepository;

        public RemoveModuleCommandHandler(IModuleWriteRepository moduleWriteRepository)
        {
            _moduleWriteRepository = moduleWriteRepository;
        }

        public async Task<RemoveModuleCommandResponse> Handle(RemoveModuleCommandRequest request, CancellationToken cancellationToken)
        {
            await _moduleWriteRepository.RemoveAsync(request.Id);
            await _moduleWriteRepository.SaveAsync();
            return new();
        }
    }
}
