using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Module.GetByIdModule
{
    public class GetByIdModuleQueryHandler : IRequestHandler<GetByIdModuleQueryRequest, GetByIdModuleQueryResponse>
    {
        readonly IModuleReadRepository _moduleReadRepository;

        public GetByIdModuleQueryHandler(IModuleReadRepository moduleReadRepository)
        {
            _moduleReadRepository = moduleReadRepository;
        }

        public async Task<GetByIdModuleQueryResponse> Handle(GetByIdModuleQueryRequest request, CancellationToken cancellationToken)
        {
           Domain.Entities.Module module= await _moduleReadRepository.GetByIdAsync(request.Id,false);
            return new()
            {
                Name = module.Name
            };
        }
    }
}
