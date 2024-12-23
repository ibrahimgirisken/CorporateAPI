using AutoMapper;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
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
            Domain.Entities.Page page = await _pageReadRepository.Table.Include(p => p.Modules).ThenInclude(pm => pm.Module).ThenInclude(m=>m.Translations).FirstOrDefaultAsync(p => p.Id == request.Id);

          _mapper.Map(request.PageDTO, page);
            var existingTranslations = page.Translations.ToList();
            page.Translations.Clear();
            foreach (var translationDto in request.PageDTO.Translations)
            {
                var translation = existingTranslations.FirstOrDefault(t => t.Locale == translationDto.Locale) ?? new PageTranslation();
                _mapper.Map(translationDto, translation);
                page.Translations.Add(translation);
            }
            var moduleIds=request.PageDTO.Modules.Select(m => m.ModuleId).ToList();
            var existingModulIds=page.Modules.Select(m => m.ModuleId).ToList();
            var modulesToRemove = page.Modules.Where(m => !moduleIds.Contains(m.ModuleId)).ToList();

            foreach (var module in modulesToRemove)
            {
                page.Modules.Remove(module);
            }
            var newModuleIds = moduleIds.Except(existingModulIds);
            foreach (var moduleId in newModuleIds)
            {
                var module = await _moduleReadRepository.GetByIdAsync(moduleId, false);
                if (module != null)
                {
                    page.Modules.Add(new PageModule { ModuleId = module.Id, PageId = page.Id });
                }
            }

            _pageWriteRepository.Update(page);
            await _pageWriteRepository.SaveAsync();

            return new();
        }
    }
}
