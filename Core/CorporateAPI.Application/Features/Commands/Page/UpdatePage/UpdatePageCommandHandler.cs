using AutoMapper;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities.Relationship;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.UpdatePage
{
    public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommandRequest, UpdatePageCommandResponse>
    {
        readonly IPageWriteRepository _pageWriteRepository;
        readonly IPageReadRepository _pageReadRepository;
        readonly IMapper _mapper;
        readonly IModuleReadRepository _moduleReadRepository;

        public UpdatePageCommandHandler(IPageWriteRepository pageWriteRepository, IPageReadRepository pageReadRepository, IMapper mapper = null, IModuleReadRepository moduleReadRepository = null)
        {
            _pageWriteRepository = pageWriteRepository;
            _pageReadRepository = pageReadRepository;
            _moduleReadRepository = moduleReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePageCommandResponse> Handle(UpdatePageCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Page page = await _pageReadRepository.GetByIdAsync(request.UpdatePage.Id);
            var pageModule = new HashSet<PageModule>();
            var pageData=_mapper.Map<Domain.Entities.Page>(request.UpdatePage);



            var moduleIds = request.UpdatePage.PageModuleIds?.Where(id => id.HasValue).Select(id => id.Value).ToList();
            if (moduleIds != null)
            {
                foreach (var item in moduleIds)
                {
                    var module = await _moduleReadRepository.GetByIdAsync(item, false);
                    if (module != null)
                    {
                        pageModule.Add(new() { ModuleId = module.Id, PageId = page.Id });
                    };
                }
            }
            if (pageModule.Any())
            {
                page.Modules.Clear();
                page.Modules= pageModule;
            }          
            
            page.Title = pageData.Title;
            page.ParentId = pageData.ParentId;
            page.Children = pageData.Children;

            _pageWriteRepository.Update(page);
            await _pageWriteRepository.SaveAsync();
            return new();
        }
    }
}
