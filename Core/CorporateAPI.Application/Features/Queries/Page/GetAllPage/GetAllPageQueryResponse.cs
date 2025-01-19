using CorporateAPI.Application.DTOs.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Page.GetAllPage
{
    public class GetAllPageQueryResponse
    {
        public List<ResultPageDTO> PagesDto { get; set; }
    }
}
