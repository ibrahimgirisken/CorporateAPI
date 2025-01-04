using AutoMapper;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        readonly IMapper _mapper;

        public GetAllModuleQueryHandler(IModuleReadRepository moduleReadRepository, IMapper mapper = null)
        {
            _moduleReadRepository = moduleReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllModuleQueryResponse> Handle(GetAllModuleQueryRequest request, CancellationToken cancellationToken)
        {
            var modules= _moduleReadRepository.GetAll(false).Include(m=>m.ModuleTranslations).ToList();
            var moduleDtos = _mapper.Map<List<ResultModuleDTO>>(modules);
            return new()
            {
                Modules = moduleDtos
            };
        }
    }
}
