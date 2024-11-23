using CorporateAPI.Application.Repositories;
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

        public CreatePageCommandHandler(IPageWriteRepository pageWriteRepository, IModuleReadRepository moduleReadRepository)
        {
            _pageWriteRepository = pageWriteRepository;
            _moduleReadRepository = moduleReadRepository;
        }

        public async Task<CreatePageCommandResponse> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var modules = new HashSet<Domain.Entities.Relationship.PageModule>();
            foreach (var mod in request.ModuleIds)
            {
               Domain.Entities.Module module= await _moduleReadRepository.GetByIdAsync(mod.ToString(), false);
                if (module != null)
                {
                    modules.Add(new Domain.Entities.Relationship.PageModule
                    {
                        Module = module,
                        Page=module.Pages.Select(x => x.Page).First()
                    });
                }
            }
            var page = new Domain.Entities.Page
            {
                Content=request.Content,
                Slug=request.Slug,
                Title=request.Title,
                Modules=modules
            };
            await _pageWriteRepository.AddAsync(page);
            await _pageWriteRepository.SaveAsync();
            return new();
        }
    }
}
