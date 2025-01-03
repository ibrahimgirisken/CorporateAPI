using AutoMapper;
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
        readonly IMapper _mapper;

        public UpdateModuleCommandHandler(IModuleWriteRepository moduleWriteRepository, IModuleReadRepository moduleReadRepository, IMapper mapper = null)
        {
            _moduleWriteRepository = moduleWriteRepository;
            _moduleReadRepository = moduleReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateModuleCommandResponse> Handle(UpdateModuleCommandRequest request, CancellationToken cancellationToken)
        {
            //Domain.Entities.Module module = await _moduleReadRepository.GetByIdAsync(request.UpdateModule.Id);
            //module=_mapper.Map<Domain.Entities.Module>(request.UpdateModule);
            //_moduleWriteRepository.Update(module);
            //await _moduleWriteRepository.SaveAsync();
            return new();
        }
    }
}
