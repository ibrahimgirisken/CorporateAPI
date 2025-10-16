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
            if (string.IsNullOrWhiteSpace(request.UrlAddress))
                return new() { pageDTO = null };

            var page = await _pageReadRepository.GetSingleAsync(
                    e => e.PageTranslations.Any(t => t.Url == request.UrlAddress),
                    tracking: false,
                    include: q => q
                        .Include(e => e.PageTranslations)
                        .ThenInclude(t => t.Lang));
               

            if (page is null)
                return new() { pageDTO = null };

            var dto = _mapper.Map<ResultPageDTO>(page);
            return new() { pageDTO = dto };
        }
    }
}
