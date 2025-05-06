using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Application.Repositories.Banner;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CorporateAPI.Application.Features.Queries.Page.GetAllPage
{
    public class GetAllPageQueryHandler : IRequestHandler<GetAllPageQueryRequest, GetAllPageQueryResponse>
    {
        readonly IPageReadRepository _pageReadRepository;
        readonly IMapper _mapper;

        public GetAllPageQueryHandler(IPageReadRepository pageReadRepository, IMapper mapper = null)
        {
            _pageReadRepository = pageReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllPageQueryResponse> Handle(GetAllPageQueryRequest request, CancellationToken cancellationToken)
        {

            if (request.IncludeAllLanguages)
            {
                var pageTranslations = _pageReadRepository.GetAll(false).Include(e => e.PageTranslations).ThenInclude(l => l.Lang).ToList();
                var pageDatas = _mapper.Map<List<ResultPageDTO>>(pageTranslations);
                return new()
                {
                    PagesDto = pageDatas
                };
            }
            var language = request.Language ?? "en";
            var bannersFiltered = _pageReadRepository.GetAll(false)
                   .Include(e => e.PageTranslations)
                       .ThenInclude(t => t.Lang)
                   .ToList();
            foreach (var banner in bannersFiltered)
            {
                banner.PageTranslations = banner.PageTranslations
                    .Where(t => t.Lang.LangCode == language)
                    .ToList();
            }

            var filteredPageDtos = _mapper.Map<List<ResultPageDTO>>(bannersFiltered);
            return new() { PagesDto = filteredPageDtos };

        }
    }
}
