using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Application.Abstractions.Services.Configurations;
using CorporateAPI.Application.Repositories.Endpoint;
using CorporateAPI.Application.Repositories.EndpointMenu;
using CorporateAPI.Domain.Entities.Endpoint;
using CorporateAPI.Domain.Entities.EndpointMenu;
using CorporateAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Services
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {
        readonly IApplicationService _applicationService;
        readonly IEndpointReadRepository _endpointReadRepository;
        readonly IEndpointWriteRepository _endpointWriteRepository;
        readonly IEndpointMenuReadRepository _endpointMenuReadRepository;
        readonly IEndpointMenuWriteRepository _endpointMenuWriteRepository;
        readonly RoleManager<AppRole> _roleManager;
        public AuthorizationEndpointService(IApplicationService applicationService, IEndpointReadRepository endpointReadRepository, IEndpointWriteRepository endpointWriteRepository, IEndpointMenuReadRepository endpointMenuReadRepository, IEndpointMenuWriteRepository endpointMenuWriteRepository = null, RoleManager<AppRole> roleManager = null)
        {
            _applicationService = applicationService;
            _endpointReadRepository = endpointReadRepository;
            _endpointWriteRepository = endpointWriteRepository;
            _endpointMenuReadRepository = endpointMenuReadRepository;
            _endpointMenuWriteRepository = endpointMenuWriteRepository;
            _roleManager = roleManager;
        }

        public async Task AssignRoleEndpointAsync(string[] roles,string endpointMenu, string code, Type type)
        {
            EndpointMenu? _endpointMenu=await _endpointMenuReadRepository.GetSingleAsync(e=>e.Name == endpointMenu); 
            if(_endpointMenu == null)
            {
                _endpointMenu = new()
                {
                    Name = endpointMenu
                };
               await _endpointMenuWriteRepository.AddAsync(_endpointMenu);
               await _endpointMenuWriteRepository.SaveAsync();
            }
            Endpoint? endpoint= await _endpointReadRepository.Table.Include(e=>e.EndpointMenu).FirstOrDefaultAsync(e=>e.Code==code&&e.EndpointMenu.Name==endpointMenu);
            if (endpoint == null)
            {
                var action= _applicationService.GetAuthorizeDefinitionEndpoints(type).FirstOrDefault(m=>m.Name==endpointMenu)?.Actions.FirstOrDefault(e=>e.Code==code);
                endpoint = new()
                {
                    Code = code,
                    ActionType = action?.ActionType,
                    HttpType = action?.HttpType,
                    Definition = action?.Definition,
                    EndpointMenu = _endpointMenu
                };

                await _endpointWriteRepository.AddAsync(endpoint);
                await _endpointWriteRepository.SaveAsync();
            }
             var appRoles =_roleManager.Roles.Where(r => roles.Contains(r.Name)).ToList();
            foreach (var role in appRoles)
                endpoint.Roles.Add(role);
           await _endpointWriteRepository.SaveAsync();
        }
    }
}
