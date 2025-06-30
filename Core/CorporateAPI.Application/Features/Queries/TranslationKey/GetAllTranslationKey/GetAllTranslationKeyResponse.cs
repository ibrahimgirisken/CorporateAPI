using CorporateAPI.Application.DTOs.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.TranslationKey.GetAllTranslationKey
{
    public class GetAllTranslationKeyResponse
    {
        public List<ResultTranslationDTO> TranslationDTO{ get; set; }
    }
}
