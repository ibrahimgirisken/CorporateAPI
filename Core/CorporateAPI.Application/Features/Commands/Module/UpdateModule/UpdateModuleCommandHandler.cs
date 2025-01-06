using AutoMapper;
using CorporateAPI.Application.Repositories;
using MediatR;

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
            var module=await _moduleReadRepository.GetByIdAsync(request.UpdateModule.Id,false,includes:e=>e.ModuleTranslations);
            var existingTranslations=module.ModuleTranslations.ToList();
            var moduleData=_mapper.Map<Domain.Entities.Module.Module>(module);
            module.ModuleTranslations.Clear();
            foreach (var translationDto in request.UpdateModule.ModuleTranslations)
            {
                var translation=existingTranslations.FirstOrDefault(t=>t.Locale==translationDto.Locale) ?? new Domain.Entities.Module.ModuleTranslation();
            }
            _moduleWriteRepository.Update(module);
            await _moduleWriteRepository.SaveAsync();
            return new();
        }
    }
}
