using CorporateAPI.Application.DTOs.Menu;
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


            List<MenuDto> GetMenuHierarchy(List<Domain.Entities.Menu> menus)
            {
                var menuDictionary = menus.ToDictionary(m => m.Id, m => m);

                foreach (var menu in menus)
                {
                    if (menu.ParentId != null && menuDictionary.ContainsKey(menu.ParentId.Value))
                    {
                        var parent = menuDictionary[menu.ParentId.Value];
                        parent.Children.Add(menu);
                    }
                }

                return menus.Where(m => m.ParentId == null).Select(m => new MenuDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Order = m.Priority,
                    Children = GetChildMenus(m.Id),
                }).ToList();
            }

             List<MenuDto> GetChildMenus(int parentId)
            {
                var childMenus = menus.Where(m=>m.ParentId== parentId).ToList();
                return childMenus.Select(m => new MenuDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Order = m.Priority,
                    Children = GetChildMenus(m.Id),
                }).ToList();
               
            }


            var getData = menus.Select(menu => new MenuDto
            {
                Id = menu.Id,
                Name = menu.Name,
                Order = menu.Priority,
                Children = menu.Children.Select(child => new MenuDto
                {
                    Id = child.Id,
                    Name = child.Name,
                    Order = child.Priority,
                }).ToList()
            }).ToList();

            return new()
            {
                Menus = GetMenuHierarchy(menus),
            };
        }
    }
}
