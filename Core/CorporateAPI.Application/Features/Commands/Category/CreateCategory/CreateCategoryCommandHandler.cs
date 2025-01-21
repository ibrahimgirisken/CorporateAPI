using AutoMapper;
using CorporateAPI.Application.Repositories.Category;
using CorporateAPI.Domain.Entities.Category;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreatecategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreatecategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.Category.Category>(request);
            if (request.CategoryTranslations!=null)
            {
                category.CategoryTranslations=_mapper.Map<List<CategoryTranslation>>(request.CategoryTranslations);
            }
            await _categoryWriteRepository.AddAsync(category);
            await _categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}
