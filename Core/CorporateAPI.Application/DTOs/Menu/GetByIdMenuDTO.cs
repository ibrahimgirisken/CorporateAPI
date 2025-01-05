using CorporateAPI.Application.DTOs.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Menu
{
    public class GetByIdMenuDTO
    {
        public int Id { get; set; }
        public bool Vitrin { get; set; }
        public bool Footer { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public ICollection<MenuTranslationDTO> Translations { get; set; }
    }
}
