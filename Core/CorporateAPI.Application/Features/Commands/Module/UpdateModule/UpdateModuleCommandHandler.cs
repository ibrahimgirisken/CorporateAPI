using AutoMapper;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities.Module;
using MediatR;
using System.Linq.Expressions;

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
            var module=await _moduleReadRepository.GetByIdAsync(request.Id,false,includes:new Expression<Func<Domain.Entities.Module.Module, object>>[]
            {
                e=>e.ModuleTranslations
            });

            var existingTranslations = module.ModuleTranslations.ToList();
            module.ModuleTranslations.Clear();
            module.ContentType=request.ContentType;
            module.Image1 = request.Image1;
            module.Image2 = request.Image2;
            module.Image3 = request.Image3;
            module.Video = request.Video;
            module.Order=request.Order;
            module.Status=request.Status;
            foreach (var translationDTO in request.ModuleTranslations)
            {
                var translation=existingTranslations.FirstOrDefault(t=>t.LangId == translationDTO.LangId) ?? new ModuleTranslation();
                _mapper.Map(translationDTO, translation);
                module.ModuleTranslations.Add(translation);
            }
            _moduleWriteRepository.Update(module);
            await _moduleWriteRepository.SaveAsync();
            return new();
        }
    }
}
