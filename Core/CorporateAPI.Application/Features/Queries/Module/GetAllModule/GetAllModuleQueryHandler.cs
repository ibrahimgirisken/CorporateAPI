using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Module.GetAllModule
{
    public class GetAllModuleQueryHandler : IRequestHandler<GetAllModuleQueryRequest, GetAllModuleQueryResponse>
    {
        readonly IModuleReadRepository _moduleReadRepository;

        public GetAllModuleQueryHandler(IModuleReadRepository moduleReadRepository)
        {
            _moduleReadRepository = moduleReadRepository;
        }

        public async Task<GetAllModuleQueryResponse> Handle(GetAllModuleQueryRequest request, CancellationToken cancellationToken)
        {
            var modules= _moduleReadRepository.GetAll(false).ToList();
            return new()
            {
                Modules = modules
            };
        }
    }
}
