using AutoMapper;
using CorporateAPI.Application.DTOs.Menu;
using CorporateAPI.Application.Repositories.Menu;
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
        readonly IMapper _mapper;

        public GetByIdMenuQueryHandler(IMenuReadRepository menuReadRepository, IMapper mapper)
        {
            _menuReadRepository = menuReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdMenuQueryResponse> Handle(GetByIdMenuQueryRequest request, CancellationToken cancellationToken)
        {
            var menu=await _menuReadRepository.GetByIdAsync(request.Id, false,includes:e=>e.MenuTranslations);

            var menuData= _mapper.Map<GetByIdMenuDTO>(menu);

            return new()
            {
                Menu= menuData
            };
        }
    }
}
