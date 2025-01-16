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
        public int Id { get; set; }
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public UpdateModuleCommandRequest()
        {
            ModuleTranslations = new HashSet<ModuleTranslationDTO>();
        }
        public ICollection<ModuleTranslationDTO> ModuleTranslations { get; set; }
    }
}
