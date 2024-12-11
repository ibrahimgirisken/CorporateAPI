using AutoMapper;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities.Relationship;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.CreatePage
{
    public class CreatePageCommandHandler : IRequestHandler<CreatePageCommandRequest, CreatePageCommandResponse>
    {
        readonly IPageWriteRepository _pageWriteRepository;
        readonly IModuleWriteRepository _moduleWriteRepository;
        readonly IModuleReadRepository _moduleReadRepository;
        readonly IMapper _mapper;

        public CreatePageCommandHandler(IPageWriteRepository pageWriteRepository, IMapper mapper = null, IModuleWriteRepository moduleWriteRepository = null, IModuleReadRepository moduleReadRepository = null)
        {
            _pageWriteRepository = pageWriteRepository;
            _moduleWriteRepository = moduleWriteRepository;
            _moduleReadRepository = moduleReadRepository;
            _mapper = mapper;
        }

        public async Task<CreatePageCommandResponse> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page = _mapper.Map<Domain.Entities.Page>(request.CreatePage);
            var pageModule=new HashSet<PageModule>();
            if (request.CreatePage.ModuleIds!=null) 
            {
                foreach (var item in request.CreatePage.ModuleIds.Where(id=>id.HasValue).Select(id=>id.Value))
                {
                    var module=await _moduleReadRepository.GetByIdAsync(item,false);
                    if (module!=null)
                    {
                        pageModule.Add(new PageModule { ModuleId = module.Id, });
                    };
                }
            }
            if (pageModule.Any())
            {
                page.PageModules = pageModule;
            }
            await _pageWriteRepository.AddAsync(page);
            await _pageWriteRepository.SaveAsync();

           
            return new();
        }
    }
}
