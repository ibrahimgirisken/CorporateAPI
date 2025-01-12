using AutoMapper;
using CorporateAPI.Application.DTOs.Page;
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
            var page= await _pageReadRepository.GetByIdAsync(request.Id, false,includes:e=>e.PageTranslations);
            var pageDto = _mapper.Map<ResultPageDTO>(page);
            return new()
            {
                Page = pageDto
            };
        }
    }
}
