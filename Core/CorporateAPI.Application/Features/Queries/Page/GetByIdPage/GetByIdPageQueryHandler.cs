using AutoMapper;
using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Page.GetByIdPage
{
    public class GetByIdPageQueryHandler : IRequestHandler<GetByIdPageQueryRequest, GetByIdPageQueryResponse>
    {
        readonly IPageReadRepository _pageReadRepository;
        readonly IMapper _mapper;

        public GetByIdPageQueryHandler(IPageReadRepository pageReadRepository, IMapper mapper = null)
        {
            _pageReadRepository = pageReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdPageQueryResponse> Handle(GetByIdPageQueryRequest request, CancellationToken cancellationToken)
        {
            var page= _mapper.Map<Domain.Entities.Page>(await _pageReadRepository.GetByIdAsync(request.Id, false));
            return new()
            {
                Page = page
            };
        }
    }
}
