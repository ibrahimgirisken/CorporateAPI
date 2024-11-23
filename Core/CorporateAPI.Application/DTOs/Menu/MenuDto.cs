using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Menu
{
    public class MenuDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public ICollection<MenuDto> Children { get; set; }
    }
}
