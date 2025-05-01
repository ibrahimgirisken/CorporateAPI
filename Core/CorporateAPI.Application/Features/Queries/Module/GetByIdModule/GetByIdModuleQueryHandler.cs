using AutoMapper;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.Repositories;
using MediatR;

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
            var module = _mapper.Map<Domain.Entities.Module.Module>(await _moduleReadRepository.GetByIdAsync(request.Id, false,includes:e=>e.ModuleTranslations));
            var moduleDto=_mapper.Map<ResultModuleDTO>(module);

            return new()
            {
                Module = moduleDto
            };
        }
    }
}
