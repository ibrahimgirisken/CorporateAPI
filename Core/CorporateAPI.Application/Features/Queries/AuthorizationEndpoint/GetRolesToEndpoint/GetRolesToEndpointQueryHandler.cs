using CorporateAPI.Application.Abstractions.Services;
using MediatR;

namespace CorporateAPI.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoints
{
    public class GetRolesToEndpointQueryHandler : IRequestHandler<GetRolesToEndpointQueryRequest, GetRolesToEndpointQueryResponse>
    {
        readonly IAuthorizationEndpointService _authorizationEndpointService;

        public GetRolesToEndpointQueryHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<GetRolesToEndpointQueryResponse> Handle(GetRolesToEndpointQueryRequest request, CancellationToken cancellationToken)
        {
           var rolesData=await _authorizationEndpointService.GetRolesToEndpointAsync(request.Code,request.EndpointMenu);
            return new()
            {
                Roles = rolesData
            };
        }
    }
}
