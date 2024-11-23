using CorporateAPI.Application.DTOs.Menu;
using CorporateAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries
{
    public class GetAllMenuQueryResponse
    {
       public List<MenuDto> Menus { get; set; }
    }
}
