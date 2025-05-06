using AutoMapper;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.Repositories;
using MediatR;
using System.Linq.Expressions;

namespace CorporateAPI.Application.Features.Queries.Module.GetByIdModule
{
    public class GetByIdModuleQueryHandler : IRequestHandler<GetByIdModuleQueryRequest, GetByIdModuleQueryResponse>
    {
        readonly IModuleReadRepository _moduleReadRepository;
        readonly IMapper _mapper;
        public GetByIdModuleQueryHandler(IModuleReadRepository moduleReadRepository, IMapper mapper = null)
        {
            _moduleReadRepository = moduleReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdModuleQueryResponse> Handle(GetByIdModuleQueryRequest request, CancellationToken cancellationToken)
        {
            var module = _mapper.Map<Domain.Entities.Module.Module>(await _moduleReadRepository.GetByIdAsync(request.Id, false,includes:new Expression<Func<Domain.Entities.Module.Module, object>>[]
            {
                        e => e.ModuleTranslations
            }, includeStrings: new[]
            {
                "ModuleTranslations.Lang"
            }));
            var moduleDto=_mapper.Map<ResultModuleDTO>(module);

            return new()
            {
                Module = moduleDto
            };
        }
    }
}
