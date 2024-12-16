using AutoMapper;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities.Relationship;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            Domain.Entities.Page page = await _pageReadRepository.Table.Include(p => p.Modules).ThenInclude(pm => pm.Module).FirstOrDefaultAsync(p => p.Id == request.Id);

            var moduleIds = request.PageDTO.PageModuleIds?.Where(id => id.HasValue).Select(id => id.Value).ToList() ?? new List<int>();

            var existingModuleIds=page.Modules.Select(pm=>pm.ModuleId).ToList();
            var modulesToRemove = page.Modules.Where(pm => !moduleIds.Contains(pm.ModuleId)).ToList();

            foreach (var moduleToRemove in modulesToRemove)
            {
                page.Modules.Remove(moduleToRemove); 
            }
            
            var pageModule = new HashSet<PageModule>();
            var pageData=_mapper.Map<Domain.Entities.Page>(request.PageDTO);

            var newModuleIds = moduleIds.Except(existingModuleIds);
            foreach (var moduleId in newModuleIds)
            {
                var module = await _moduleReadRepository.GetByIdAsync(moduleId, false);
                if (module != null)
                {
                    page.Modules.Add(new PageModule { Module = module });
                }
            }

            page.ParentId = pageData.ParentId;
            page.Children = pageData.Children;

            _pageWriteRepository.Update(page);
            await _pageWriteRepository.SaveAsync();
            return new();
        }
    }
}
