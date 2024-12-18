
using CorporateAPI.WebUI.DTOs.Module;

namespace CorporateAPI.WebUI.DTOs.PageModule
{
    public class ResultPageModuleDTO
    {
        public int PageId { get; set; }
        public int ModuleId { get; set; }
        public int Order { get; set; }
        public GetModuleDTO Module { get; set; }

    }
}
