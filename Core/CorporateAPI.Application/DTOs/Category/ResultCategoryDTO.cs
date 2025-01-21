using CorporateAPI.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Category
{
    public class ResultCategoryDTO
    {
        public string? Image1 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; } = false;
        public List<ResultCategoryDTO> Children { get; set; }
        public List<CategoryTranslationDTO> CategoryTranslations { get; set; }
    }
}
