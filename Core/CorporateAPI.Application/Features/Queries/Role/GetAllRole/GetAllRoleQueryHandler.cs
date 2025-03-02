using CorporateAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Role.GetAllRole
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest, GetAllRoleQueryResponse>
    {
        readonly IRoleService _roleService;

        public GetAllRoleQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public Task<GetAllRoleQueryResponse> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var (datas,count) = _roleService.GetAllRoles(request.Page,request.Size);
            return Task.FromResult(new GetAllRoleQueryResponse
            {
                Datas = datas,
                TotalCount = count
            });
        }
    }
}
