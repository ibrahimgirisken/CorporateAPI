using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Translation
{
    public class TranslationValueDTO
    {
        public string LangCode { get; set; } = string.Empty;
        public string Value { get; set; } = null!;
    }
}
