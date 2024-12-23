using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Module
{
    public class CreateModuleDTO
    {
        public CreateModuleDTO()
        {
            Translsations=new HashSet<CreateModuleTranslationDTO>();
        }
        public ICollection<CreateModuleTranslationDTO> Translsations { get; set; }

    }
}
