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

            if (request.IncludeAllLanguages)
            {
                var categoryTranslations = await _categoryReadRepository.GetAll(false).Include(e => e.CategoryTranslations).ThenInclude(l => l.Lang).ToListAsync();
                var categoryDatas = _mapper.Map<List<ResultCategoryDTO>>(categoryTranslations);
                return new()
                {
                    CategoriesDto = categoryDatas
                };
            }
            var language = request.Language ?? "en";
            var categoriesFiltered = _categoryReadRepository.GetAll(false).Where(b => !b.IsDeleted)
                   .Include(e => e.CategoryTranslations)
                       .ThenInclude(t => t.Lang)
                   .ToList();
            foreach (var category in categoriesFiltered)
            {
                category.CategoryTranslations = category.CategoryTranslations
                    .Where(t => t.Lang.LangCode == language)
                    .ToList();
            }

            var filteredCategoryDtos = _mapper.Map<List<ResultCategoryDTO>>(categoriesFiltered);
            return new() { CategoriesDto = filteredCategoryDtos };

        }
    }
}
