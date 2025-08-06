using MediatR;

namespace CorporateAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint
{
    public class AssignRoleEndpointCommandRequest:IRequest<AssignRoleEndpointCommandResponse>
    {
        public string[] Roles { get; set; }
        public string EndpointCode { get; set; }
        public string EndpointMenu { get; set; }
        public Type? Type { get; set; }

    }
}
