using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Menu.GetByIdMenu
{
    public class GetByIdMenuQueryHandler : IRequestHandler<GetByIdMenuQueryRequest, GetByIdMenuQueryResponse>
    {
        readonly IMenuReadRepository _menuReadRepository;

        public GetByIdMenuQueryHandler(IMenuReadRepository menuReadRepository)
        {
            _menuReadRepository = menuReadRepository;
        }

        public async Task<GetByIdMenuQueryResponse> Handle(GetByIdMenuQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Menu menu= await _menuReadRepository.GetByIdAsync(request.Id,false);
            return new()
            {
                Order = menu.Order,
                Title = menu.Title,
                Url = menu.Url,
            };
        }
    }
}
