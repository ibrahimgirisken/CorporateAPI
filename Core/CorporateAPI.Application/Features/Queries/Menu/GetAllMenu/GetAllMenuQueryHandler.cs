using AutoMapper;
using CorporateAPI.Application.DTOs.Menu;
using CorporateAPI.Application.Repositories.Menu;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CorporateAPI.Application.Features.Queries.Menu.GetAllMenu
{
    public class GetAllMenuQueryHandler : IRequestHandler<GetAllMenuQueryRequest, GetAllMenuQueryResponse>
    {
        readonly IMenuReadRepository _menuReadRepository;
        readonly IMapper _mapper;
        public GetAllMenuQueryHandler(IMenuReadRepository menuReadRepository, IMapper mapper)
        {
            _menuReadRepository = menuReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllMenuQueryResponse> Handle(GetAllMenuQueryRequest request, CancellationToken cancellationToken)
        {
            var menus= _menuReadRepository.GetAll(false).Include(e=>e.MenuTranslations).ToList();
            var menusData= _mapper.Map<List<ResultMenuDTO>>(menus);
            return new()
            {
                menusDto= menusData
            };
        }
    }
}
