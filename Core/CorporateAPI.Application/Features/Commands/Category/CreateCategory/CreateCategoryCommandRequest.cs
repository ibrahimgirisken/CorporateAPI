using CorporateAPI.Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest:IRequest<CreatecategoryCommandResponse>
    {
        public CreateCategoryCommandRequest()
        {
            Children = new List<ResultCategoryDTO>();
            CategoryTranslations = new List<CategoryTranslationDTO>();
        }
        public string? Image1 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; } = false;
        public List<ResultCategoryDTO> Children { get; set; }
        public List<CategoryTranslationDTO> CategoryTranslations { get; set; }
    }
}
