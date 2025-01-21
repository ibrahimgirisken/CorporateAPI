using AutoMapper;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities.Module;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Module.CreateModule
{
    public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommandRequest, CreateModuleCommandResponse>
    {
        readonly IModuleWriteRepository _moduleWriteRepository;
        readonly IMapper _mapper;
        public CreateModuleCommandHandler(IModuleWriteRepository moduleWriteRepository, IMapper mapper)
        {
            _moduleWriteRepository = moduleWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateModuleCommandResponse> Handle(CreateModuleCommandRequest request, CancellationToken cancellationToken)
        {
            var module=_mapper.Map<Domain.Entities.Module.Module>(request);
            if (request.ModuleTranslations != null)
            {
               module.ModuleTranslations=_mapper.Map<List<ModuleTranslation>>(request.ModuleTranslations);
            }
            await _moduleWriteRepository.AddAsync(module);
            await _moduleWriteRepository.SaveAsync();
            return new();
        }
    }
}
