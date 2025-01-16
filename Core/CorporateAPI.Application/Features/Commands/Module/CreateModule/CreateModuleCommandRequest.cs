using CorporateAPI.Application.DTOs.Module;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Module.CreateModule
{
    public class CreateModuleCommandRequest:IRequest<CreateModuleCommandResponse>
    {
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public CreateModuleDTO Module { get; set; }
    }
}
