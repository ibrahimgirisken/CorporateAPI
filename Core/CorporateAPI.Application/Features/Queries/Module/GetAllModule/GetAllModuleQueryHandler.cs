using AutoMapper;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CorporateAPI.Application.Features.Queries.Module.GetAllModule
{
    public class GetAllModuleQueryHandler : IRequestHandler<GetAllModuleQueryRequest, GetAllModuleQueryResponse>
    {
        readonly IModuleReadRepository _moduleReadRepository;
        readonly IMapper _mapper;

        public GetAllModuleQueryHandler(IModuleReadRepository moduleReadRepository, IMapper mapper = null)
        {
            _moduleReadRepository = moduleReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllModuleQueryResponse> Handle(GetAllModuleQueryRequest request, CancellationToken cancellationToken)
        {

            if (request.IncludeAllLanguages)
            {
                var moduleTranslations = _moduleReadRepository.GetAll(false).Include(e => e.ModuleTranslations).ThenInclude(l=>l.Lang).ToList();
                var moduleDatas = _mapper.Map<List<ResultModuleDTO>>(moduleTranslations);
                return new()
                {
                    ModulesDto = moduleDatas
                };
            }
            var language = request.Language ?? "en";
            var modulesFiltered = _moduleReadRepository.GetAll(false)
                   .Include(e => e.ModuleTranslations)
                       .ThenInclude(t => t.Lang)
                   .ToList();
            foreach (var module in modulesFiltered)
            {
                module.ModuleTranslations = module.ModuleTranslations
                    .Where(t => t.Lang.LangCode == language)
                    .ToList();
            }

            var filteredModuleDtos = _mapper.Map<List<ResultModuleDTO>>(modulesFiltered);
            return new() { ModulesDto = filteredModuleDtos };

        }
    }
}
