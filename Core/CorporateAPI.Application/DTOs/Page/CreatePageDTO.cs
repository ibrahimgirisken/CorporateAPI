using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Page
{
    public class CreatePageDTO
    {
        public string Title { get; set; }
        public int? ParentId { get; set; }
    }

}
