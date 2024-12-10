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
        readonly IModuleReadRepository _moduleReadRepository;
        readonly IMapper _mapper;

        public CreatePageCommandHandler(IPageWriteRepository pageWriteRepository, IModuleReadRepository moduleReadRepository, IMapper mapper = null)
        {
            _pageWriteRepository = pageWriteRepository;
            _moduleReadRepository = moduleReadRepository;
            _mapper = mapper;
        }

        public async Task<CreatePageCommandResponse> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page = _mapper.Map<Domain.Entities.Page>(request.CreatePage);

            await _pageWriteRepository.AddAsync(page);
            await _pageWriteRepository.SaveAsync();



            //var pageModules = new HashSet<PageModule>();

            //foreach (var mod in request.CreatePage.ModuleIds.Where(id => id.HasValue).Select(id => id.Value))
            //{
            //    Domain.Entities.Module module = await _moduleReadRepository.GetByIdAsync(mod, false);
            //    if (module != null)
            //    {
            //        pageModules.Add(new PageModule
            //        {
            //            Module = module,
            //            Page = page
            //        });
            //    }
            //}

            //if (pageModules.Any())
            //{
            //    page.PageModules = pageModules;
            //}
            //await _pageWriteRepository.SaveAsync();

            return new();
        }
    }
}
