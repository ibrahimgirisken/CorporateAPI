using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.PageDto
{
    public class PageDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public int? ParentId { get; set; } = 0;
        public string Type { get; set; }
        public int Order { get; set; } = 1;
        public bool Status { get; set; } = true;
        public virtual List<PageDto> SubPages { get; set; }
    }
}
