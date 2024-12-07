using CorporateAPI.Application.DTOs.PageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Page.GetAllPage
{
    public class GetAllPageQueryResponse
    {
        public List<PageDto> Pages { get; set; }
    }
}
