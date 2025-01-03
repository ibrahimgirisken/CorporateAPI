using AutoMapper;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
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
        readonly IMapper _mapper;
        public CreateModuleCommandHandler(IModuleWriteRepository moduleWriteRepository, IMapper mapper)
        {
            _moduleWriteRepository = moduleWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateModuleCommandResponse> Handle(CreateModuleCommandRequest request, CancellationToken cancellationToken)
        {
            //var module = _mapper.Map<Domain.Entities.Module>(request.Module);

            //if (request.Module.Translations != null)
            //{
            //    var moduleTranslations = new List<ModuleTranslation>();
            //    foreach (var moduleTranslation in request.Module.Translations)
            //    {
            //        var translation = new ModuleTranslation
            //        {
            //            Locale = moduleTranslation.Locale,
            //            Name = moduleTranslation.Name,
            //            ModuleData = moduleTranslation.ModuleData,
            //            Module = module
            //        };
            //        moduleTranslations.Add(translation);
            //    }
            //    module.ModuleTranslations = moduleTranslations;
            //}

            //await _moduleWriteRepository.AddAsync(module);
            //await _moduleWriteRepository.SaveAsync();

            return new();
        }
    }
}
