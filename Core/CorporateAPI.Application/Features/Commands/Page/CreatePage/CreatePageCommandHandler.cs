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

        public CreatePageCommandHandler(IPageWriteRepository pageWriteRepository, IModuleReadRepository moduleReadRepository)
        {
            _pageWriteRepository = pageWriteRepository;
            _moduleReadRepository = moduleReadRepository;
        }

        public async Task<CreatePageCommandResponse> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page = new Domain.Entities.Page
            {
                Content = request.Content,
                Slug = request.Slug,
                Title = request.Title
            };

            await _pageWriteRepository.AddAsync(page);
            await _pageWriteRepository.SaveAsync();

            var pageModules = new HashSet<PageModule>();

            foreach (var mod in request.ModuleIds.Where(id => id.HasValue).Select(id => id.Value))
            {
                Domain.Entities.Module module = await _moduleReadRepository.GetByIdAsync(mod.ToString(), false);
                if (module != null)
                {
                    pageModules.Add(new PageModule
                    {
                        Module = module,
                        Page = page
                    });
                }
            }

            if (pageModules.Any())
            {
                page.Modules = pageModules;
            }
            await _pageWriteRepository.SaveAsync();

            return new();
        }
    }
}
