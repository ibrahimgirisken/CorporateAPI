using AutoMapper;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities.Module;
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
            foreach (var translationDto in request.UpdateModule.ModuleTranslations)
            {
               var existingTranslation=module.ModuleTranslations.FirstOrDefault(t=>t.Locale==translationDto.Locale);
                if (existingTranslation!=null)
                {
                    _mapper.Map(translationDto, existingTranslation);
                }else
                {
                    var newTranslation=_mapper.Map<ModuleTranslation>(translationDto);
                    module.ModuleTranslations.Add(newTranslation);
                }
            }
            _moduleWriteRepository.Update(module);
            await _moduleWriteRepository.SaveAsync();
            return new();
        }
    }
}
