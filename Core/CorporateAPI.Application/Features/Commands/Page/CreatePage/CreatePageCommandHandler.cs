using AutoMapper;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
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

        public CreatePageCommandHandler(IPageWriteRepository pageWriteRepository, IMapper mapper = null, IModuleReadRepository moduleReadRepository = null)
        {
            _pageWriteRepository = pageWriteRepository;
            _moduleReadRepository = moduleReadRepository;
            _mapper = mapper;
        }

        public async Task<CreatePageCommandResponse> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            //var page = _mapper.Map<Domain.Entities.Page>(request.PageDto);
            //var pageModule=new HashSet<PageModule>();
            //var pageTranslations = new HashSet<PageTranslation>();
            //if (request.PageDto.Translations!=null)
            //{
            //    foreach (var item in request.PageDto.Translations)
            //    {
            //        var translation = new PageTranslation
            //        {
            //            Locale = item.Locale,
            //            Title = item.Title,
            //        };
            //        pageTranslations.Add(translation);
            //    }
            //}
            //if (request.PageDto.Modules != null) 
            //{
            //    foreach (var item in request.PageDto.Modules)
            //    {
            //        var module=await _moduleReadRepository.GetByIdAsync(item.ModuleId,false);
            //        if (module!=null)
            //        {
            //            pageModule.Add(new(){ ModuleId = module.Id,PageId=page.Id,Order=item.Order});
            //        };
            //    }
            //}
            //if (pageModule.Any())
            //{
            //    page.Modules = pageModule;
            //    page.PageTranslations = pageTranslations;
            //}
            //await _pageWriteRepository.AddAsync(page);
            await _pageWriteRepository.SaveAsync();

           
            return new();
        }
    }
}
