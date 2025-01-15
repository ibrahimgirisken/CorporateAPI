using AutoMapper;
using CorporateAPI.Application.DTOs.Home;
using CorporateAPI.Application.Repositories.Home;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var homes= _homeReadRepository.GetAll().Include(e=>e.HomeTranslations).ToList();
            var responseDatas= _mapper.Map<List<ResultHomeDTO>>(homes);
            return new()
            {
                Homes=responseDatas
            };
        }
    }
}
