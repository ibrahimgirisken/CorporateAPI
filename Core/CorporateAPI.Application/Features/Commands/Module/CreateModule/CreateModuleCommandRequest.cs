using CorporateAPI.Application.DTOs.Module;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Module.CreateModule
{
    public class CreateModuleCommandRequest:IRequest<CreateModuleCommandResponse>
    {
        public CreateModuleDTO Module { get; set; }
    }
}
