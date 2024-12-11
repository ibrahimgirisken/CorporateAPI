using AutoMapper;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Relationship;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Page.GetAllPage
{
    public class GetAllPageQueryHandler : IRequestHandler<GetAllPageQueryRequest, GetAllPageQueryResponse>
    {
        readonly IPageReadRepository _pageReadRepository;
        readonly IMapper _mapper;

        public GetAllPageQueryHandler(IPageReadRepository pageReadRepository, IMapper mapper = null)
        {
            _pageReadRepository = pageReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllPageQueryResponse> Handle(GetAllPageQueryRequest request, CancellationToken cancellationToken)
        {
            var pages = _pageReadRepository.GetAll(false).Include(p=>p.PageModules).ToList();
            var pageDtos = _mapper.Map<List<ResultPageDTO>>(pages);

            return new()
            {
                Pages= pageDtos,
            };

        }
    }
}
