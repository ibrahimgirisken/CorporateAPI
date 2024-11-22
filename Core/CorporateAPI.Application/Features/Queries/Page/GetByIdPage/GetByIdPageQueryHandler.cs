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

        public GetByIdPageQueryHandler(IPageReadRepository pageReadRepository)
        {
            _pageReadRepository = pageReadRepository;
        }

        public async Task<GetByIdPageQueryResponse> Handle(GetByIdPageQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Page page= await _pageReadRepository.GetByIdAsync(request.Id,false);
            return new()
            {
                Content = page.Content
            };
        }
    }
}
