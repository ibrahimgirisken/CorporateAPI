using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
using MediatR;
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

        public GetAllPageQueryHandler(IPageReadRepository pageReadRepository)
        {
            _pageReadRepository = pageReadRepository;
        }

        public async Task<GetAllPageQueryResponse> Handle(GetAllPageQueryRequest request, CancellationToken cancellationToken)
        {
            var pages = _pageReadRepository.GetAll(false).ToList();
            return new()
            {
                Pages=pages,
            };
        }
    }
}
