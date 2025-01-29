using AutoMapper;
using CorporateAPI.Application.DTOs.Home;
using CorporateAPI.Application.Repositories.Home;
using MediatR;

namespace CorporateAPI.Application.Features.Queries.Home.GetByContentTypeHome
{
    public class GetByContentTypeHomeQueryHandler : IRequestHandler<GetByContentTypeHomeQueryRequest, GetByContentTypeHomeQueryResponse>
    {
        readonly IHomeReadRepository _homeReadRepository;
        readonly IMapper _mapper;
        public GetByContentTypeHomeQueryHandler(IHomeReadRepository homeReadRepository, IMapper mapper)
        {
            _homeReadRepository = homeReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByContentTypeHomeQueryResponse> Handle(GetByContentTypeHomeQueryRequest request, CancellationToken cancellationToken)
        {
            var language = request.Language ?? "en";
            var home = await _homeReadRepository.GetSingleAsync(
                p => p.ContentType == request.ContentType,
                false,
                includes: e => e.HomeTranslations.Where(t => t.Locale == language));
            var response = _mapper.Map<ResultHomeDTO>(home);

            return new()
            {
                homeDTO = response
            };
        }
    }
}
