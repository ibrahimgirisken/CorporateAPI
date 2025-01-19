using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Module.GetAllModule
{
    public class GetAllModuleQueryRequest:IRequest<GetAllModuleQueryResponse>
    {
        public string? Language { get; set; }
        public bool IncludeAllLanguages { get; set; } = false;
    }
}
