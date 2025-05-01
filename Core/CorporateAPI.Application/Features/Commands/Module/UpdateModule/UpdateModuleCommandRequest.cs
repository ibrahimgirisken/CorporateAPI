using CorporateAPI.Application.DTOs.Module;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Module.UpdateModule
{
    public class UpdateModuleCommandRequest:IRequest<UpdateModuleCommandResponse>
    {
        public string Id { get; set; }
        public string ContentType { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Video { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public UpdateModuleCommandRequest()
        {
            ModuleTranslations = new List<ModuleTranslationDTO>();
        }
        public List<ModuleTranslationDTO> ModuleTranslations { get; set; }
    }
}
