using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Module.UpdateModule
{
    public class UpdateModuleCommandHandler : IRequestHandler<UpdateModuleCommandRequest, UpdateModuleCommandResponse>
    {
        readonly IModuleWriteRepository _moduleWriteRepository;
        readonly IModuleReadRepository _moduleReadRepository;

        public UpdateModuleCommandHandler(IModuleWriteRepository moduleWriteRepository, IModuleReadRepository moduleReadRepository)
        {
            _moduleWriteRepository = moduleWriteRepository;
            _moduleReadRepository = moduleReadRepository;
        }

        public async Task<UpdateModuleCommandResponse> Handle(UpdateModuleCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Module module = await _moduleReadRepository.GetByIdAsync(request.Id);
            module.Name = request.Name;
            _moduleWriteRepository.Update(module);
            await _moduleWriteRepository.SaveAsync();
            return new();
        }
    }
}
