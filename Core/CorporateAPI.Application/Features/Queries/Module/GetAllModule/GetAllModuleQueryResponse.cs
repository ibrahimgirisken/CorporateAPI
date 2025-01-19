using CorporateAPI.Application.DTOs.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Module.GetAllModule
{
    public class GetAllModuleQueryResponse
    {
        public List<ResultModuleDTO> ModulesDto{ get; set; }
    }
}
