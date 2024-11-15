using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Menu.GetAllMenu
{
    public class GetAllMenuQueryHandler : IRequestHandler<GetAllMenuQueryRequest, GetAllMenuQueryResponse>
    {
        readonly IMenuReadRepository _menuReadRepository;

        public GetAllMenuQueryHandler(IMenuReadRepository menuReadRepository)
        {
            _menuReadRepository = menuReadRepository;
        }

        public async Task<GetAllMenuQueryResponse> Handle(GetAllMenuQueryRequest request, CancellationToken cancellationToken)
        {
            var menus = _menuReadRepository.GetAll(false).ToList();
            return new()
            {
                Menus = menus,
            };
        }
    }
}
