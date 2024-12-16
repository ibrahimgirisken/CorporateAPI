using CorporateAPI.Application.DTOs.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.PageModule
{
    public class ResultPageModuleDTO
    {
        public int PageId { get; set; }
        public int ModuleId { get; set; }
        public int Order { get; set; }
        public GetModuleDTO Module { get; set; }
    }
}
