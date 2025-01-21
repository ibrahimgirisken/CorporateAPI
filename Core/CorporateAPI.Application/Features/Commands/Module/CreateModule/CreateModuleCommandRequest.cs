using CorporateAPI.Application.DTOs.Module;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Module.CreateModule
{
    public class CreateModuleCommandRequest:IRequest<CreateModuleCommandResponse>
    {
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public CreateModuleCommandRequest()
        {
            ModuleTranslations = new List<ModuleTranslationDTO>();
        }
        public List<ModuleTranslationDTO> ModuleTranslations { get; set; }
    }
}
