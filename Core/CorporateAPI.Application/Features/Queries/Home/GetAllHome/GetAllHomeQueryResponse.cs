using CorporateAPI.Application.DTOs.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Home.GetAllHome
{
    public class GetAllHomeQueryResponse
    {
        public List<ResultHomeDTO> Homes { get; set; }
    }
}
