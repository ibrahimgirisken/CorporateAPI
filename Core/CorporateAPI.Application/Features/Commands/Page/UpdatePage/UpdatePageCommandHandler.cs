using AutoMapper;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
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
            Domain.Entities.Page page = await _pageReadRepository.GetByIdAsync(request.Id,false,includes:e=>e.PageTranslations);

           var pageData= _mapper.Map<Domain.Entities.Page>(page);

            var existingTranslations = pageData.PageTranslations.ToList();
            page.PageTranslations.Clear();
            foreach (var translationDto in request.PageDTO.Translations)
            {
                var translation = existingTranslations.FirstOrDefault(t => t.Locale == translationDto.Locale) ?? new PageTranslation();
                _mapper.Map(translationDto, translation);
                pageData.PageTranslations.Add(translation);
            }

            _pageWriteRepository.Update(pageData);
            await _pageWriteRepository.SaveAsync();

            return new();
        }
    }
}
