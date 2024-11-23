using CorporateAPI.Application.DTOs.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Menu.GetByIdMenu
{
    public class GetByIdMenuQueryResponse
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public ICollection<MenuDto> Children { get; set; }
    }
}
