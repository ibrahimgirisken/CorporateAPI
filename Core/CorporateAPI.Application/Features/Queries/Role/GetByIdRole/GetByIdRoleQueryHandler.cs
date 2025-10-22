using CorporateAPI.Application.Abstractions.Services;
using MediatR;

namespace CorporateAPI.Application.Features.Queries.Role.GetByIdRole
{
    public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQueryRequest, GetByIdRoleQueryResponse>
    {
        readonly IRoleService _roleService;

        public GetByIdRoleQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetByIdRoleQueryResponse> Handle(GetByIdRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var result =await _roleService.GetRoleById(request.Id);
            return new()
            {
                Id = result.id,
                Name = result.name
            };
        }
    }
}
