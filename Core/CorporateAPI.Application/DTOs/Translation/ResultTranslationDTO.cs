using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Translation
{
    public class ResultTranslationDTO
    {
        public string Key { get; set; }
        public string? Description { get; set; }
        public List<TranslationValueDTO> Translations { get; set; }
    }
}
