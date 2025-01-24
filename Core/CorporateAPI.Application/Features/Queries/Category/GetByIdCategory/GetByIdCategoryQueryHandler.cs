using AutoMapper;
using CorporateAPI.Application.DTOs.Category;
using CorporateAPI.Application.Repositories.Category;
using MediatR;

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
            var category= await _categoryReadRepository.GetByIdAsync(request.Id,false,includes:e=>e.CategoryTranslations);
            var categoryDto=_mapper.Map<ResultCategoryDTO>(category);
            return new()
            {
                CategoryDTO = categoryDto
            };
        }
    }
}
