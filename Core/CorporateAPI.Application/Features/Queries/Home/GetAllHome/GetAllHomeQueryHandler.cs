using AutoMapper;
using CorporateAPI.Application.DTOs.Home;
using CorporateAPI.Application.Repositories.Home;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CorporateAPI.Application.Features.Queries.Home.GetAllHome
{
    public class GetAllHomeQueryHandler : IRequestHandler<GetAllHomeQueryRequest, GetAllHomeQueryResponse>
    {
        readonly IHomeReadRepository _homeReadRepository;
        readonly IMapper _mapper;
        public GetAllHomeQueryHandler(IHomeReadRepository homeReadRepository, IMapper mapper)
        {
            _homeReadRepository = homeReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllHomeQueryResponse> Handle(GetAllHomeQueryRequest request, CancellationToken cancellationToken)
        {
            var homes=await _homeReadRepository.GetAll(false).Include(e=>e.HomeTranslations).ToListAsync();
            var responseDatas= _mapper.Map<List<ResultHomeDTO>>(homes);
            return new()
            {
                Homes=responseDatas
            };
        }
    }
}
