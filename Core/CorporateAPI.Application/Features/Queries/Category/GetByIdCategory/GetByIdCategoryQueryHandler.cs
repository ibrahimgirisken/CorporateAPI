using AutoMapper;
using CorporateAPI.Application.DTOs.Category;
using CorporateAPI.Application.Repositories.Category;
using MediatR;
using System.Linq.Expressions;

namespace CorporateAPI.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category= await _categoryReadRepository.GetByIdAsync(request.Id, false, includes:new Expression< Func<Domain.Entities.Category.Category, object>>[]
                {
                e => e.CategoryTranslations
                },
            includeStrings: new[]
            {
                "CategoryTranslations.Lang"
            });
            var categoryDto=_mapper.Map<ResultCategoryDTO>(category);
            return new()
            {
                CategoryDTO = categoryDto
            };
        }
    }
}
