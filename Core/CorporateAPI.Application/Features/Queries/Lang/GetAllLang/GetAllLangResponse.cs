using CorporateAPI.Application.DTOs.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Lang.GetAllLang
{
    public class GetAllLangResponse
    {
      public List<GetLangDTO> LangData { get; set; }
    }
}
