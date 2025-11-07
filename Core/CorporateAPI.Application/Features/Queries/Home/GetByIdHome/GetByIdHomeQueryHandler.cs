using AutoMapper;
using CorporateAPI.Application.DTOs.Home;
using CorporateAPI.Application.Repositories.Home;
using MediatR;
using System.Linq.Expressions;

namespace CorporateAPI.Application.Features.Queries.Home.GetByIdHome
{
    public class GetByIdHomeQueryHandler : IRequestHandler<GetByIdHomeQueryRequest, GetByIdHomeQueryResponse>
    {
        readonly IHomeReadRepository _homeReadRepository;
        readonly IMapper _mapper;

        public GetByIdHomeQueryHandler(IHomeReadRepository homeReadRepository, IMapper mapper)
        {
            _homeReadRepository = homeReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdHomeQueryResponse> Handle(GetByIdHomeQueryRequest request, CancellationToken cancellationToken)
        {
            var home= await _homeReadRepository.GetByIdAsync(request.Id,false,includes:new Expression<Func<Domain.Entities.Home.Home, object>>[]
            {
                e => e.HomeTranslations
            },
            includeStrings: new[]
            {
                "HomeTranslations.Lang"
            });
            var resposeDto= _mapper.Map<ResultHomeDTO>(home);
            return new()
            {
                home= resposeDto,
            };
        }
    }
}
