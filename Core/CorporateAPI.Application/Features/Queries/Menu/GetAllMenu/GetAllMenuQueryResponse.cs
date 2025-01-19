using CorporateAPI.Application.DTOs.Menu;

namespace CorporateAPI.Application.Features.Queries.Menu.GetAllMenu
{
    public class GetAllMenuQueryResponse
    {
        public List<ResultMenuDTO> MenusDto{ get; set; }
    }
}