using AutoMapper;
using CorporateAPI.Application.DTOs.Category;
using CorporateAPI.Application.Repositories.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CorporateAPI.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
              var categories= await _categoryReadRepository.GetAll(false).Include(c=>c.CategoryTranslations).ToListAsync();
            var categoriesDto=_mapper.Map<List<ResultCategoryDTO>>(categories);
            return new()
            {
                CategoriesDto = categoriesDto,
            };
        }
    }
}
