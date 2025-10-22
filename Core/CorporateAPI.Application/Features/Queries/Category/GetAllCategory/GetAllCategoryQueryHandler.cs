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

            var categoryTranslations = _categoryReadRepository.GetAll(false).Include(e => e.CategoryTranslations).ThenInclude(l => l.Lang).ToList();
            var categoryDatas = _mapper.Map<List<ResultCategoryDTO>>(categoryTranslations);
            return new()
            {
                CategoriesDto = categoryDatas
            };

        }
    }
}
