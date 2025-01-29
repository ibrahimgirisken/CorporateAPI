using AutoMapper;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.Repositories;
using MediatR;
using System.Security.Policy;


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
            var page = await _pageReadRepository.GetSingleAsync(e => e.PageTranslations.Any(t => t.Url == request.UrlAddress && t.Locale == language),false, includes: e => e.PageTranslations);

            if (page != null)
            {
                page.PageTranslations = new List<Domain.Entities.PageTranslation>
                {
                    page.PageTranslations.FirstOrDefault(t => t.Locale == language)
                };
              
            }
            var response = _mapper.Map<ResultPageDTO>(page);
            return new()
            {
                pageDTO = response
            };
        }
    }
}
