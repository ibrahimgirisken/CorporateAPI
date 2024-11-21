using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Module.CreateModule
{
    public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommandRequest, CreateModuleCommandResponse>
    {
        readonly IModuleWriteRepository _moduleWriteRepository;

        public CreateModuleCommandHandler(IModuleWriteRepository moduleWriteRepository)
        {
            _moduleWriteRepository = moduleWriteRepository;
        }

        public async Task<CreateModuleCommandResponse> Handle(CreateModuleCommandRequest request, CancellationToken cancellationToken)
        {
            await _moduleWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Type = request.Type
            });
            await _moduleWriteRepository.SaveAsync();
            return new();
        }
    }
}
