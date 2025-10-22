using CorporateAPI.Application.DTOs.Category;

namespace CorporateAPI.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryResponse
    {
        public List<ResultCategoryDTO> CategoriesDto { get; set; }
    }
}
