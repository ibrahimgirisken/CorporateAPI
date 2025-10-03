using AutoMapper;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CorporateAPI.Application.Features.Queries.Page.GetByUrlAddressPage
{
    public class GetByUrlAddressPageQueryHandler : IRequestHandler<GetByUrlAddressPageQueryRequest, GetByUrlAddressPageQueryResponse>
    {
        readonly IPageReadRepository _pageReadRepository;
        readonly IMapper _mapper;

        public GetByUrlAddressPageQueryHandler(IPageReadRepository pageReadRepository, IMapper mapper)
        {
            _pageReadRepository = pageReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByUrlAddressPageQueryResponse> Handle(GetByUrlAddressPageQueryRequest request, CancellationToken cancellationToken)
        {
            var language = request.Language ?? "en";

            var page = await _pageReadRepository.GetSingleAsync(
                e => e.PageTranslations.Any(t => t.Url == request.UrlAddress && t.Lang.LangCode == language),
                tracking: false,
                include: q => q
                    .Include(e => e.PageTranslations.Where(t => t.Lang.LangCode == language)) // EF Core 5+ filtered include
                    .ThenInclude(t => t.Lang)
            );
            if (page != null)
            {
                page.PageTranslations = page.PageTranslations
                    .Where(t => t.Lang.LangCode == language)
                    .ToList();
            }

            var response = page != null ? _mapper.Map<ResultPageDTO>(page) : null;

            return new()
            {
                pageDTO = response
            };
        }
    }
}
