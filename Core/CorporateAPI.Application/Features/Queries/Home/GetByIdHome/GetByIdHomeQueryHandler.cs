using AutoMapper;
using CorporateAPI.Application.DTOs.Home;
using CorporateAPI.Application.Repositories.Home;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var home= await _homeReadRepository.GetByIdAsync(request.Id);
            var respose= _mapper.Map<ResultHomeDTO>(home);
            return new()
            {
                homeDTO=respose,
            };
        }
    }
}
