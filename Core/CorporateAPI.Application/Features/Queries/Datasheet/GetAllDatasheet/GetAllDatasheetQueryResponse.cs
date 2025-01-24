using CorporateAPI.Application.DTOs.Datasheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Datasheet.GetAllDatasheet
{
    public class GetAllDatasheetQueryResponse
    {
       public List<ResultDatasheetDTO> resultDatasheetsDto { get; set; }
    }
}
