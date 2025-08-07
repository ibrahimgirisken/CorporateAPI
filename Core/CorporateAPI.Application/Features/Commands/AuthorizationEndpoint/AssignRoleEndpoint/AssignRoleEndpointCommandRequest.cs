using MediatR;
using System.Text.Json.Serialization;

namespace CorporateAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint
{
    public class AssignRoleEndpointCommandRequest:IRequest<AssignRoleEndpointCommandResponse>
    {
        public string[] Roles { get; set; }
        public string EndpointCode { get; set; }
        public string EndpointMenu { get; set; }
        [JsonIgnore]
        public Type? Type { get; set; }

    }
}
