using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Page
{
    public class ResultPageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<ResultPageDTO?> Children { get; set; }

    }
}
