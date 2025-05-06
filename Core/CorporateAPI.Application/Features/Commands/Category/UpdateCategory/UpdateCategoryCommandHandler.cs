using AutoMapper;
using CorporateAPI.Application.Repositories.Category;
using CorporateAPI.Domain.Entities.Category;
using MediatR;
using System.Linq.Expressions;

namespace CorporateAPI.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category.Category category=await _categoryReadRepository.GetByIdAsync(request.Id,false,includes:new Expression<Func<Domain.Entities.Category.Category, object>>[]
            {
                e => e.CategoryTranslations
            },
            includeStrings: new[]
            {
                "CategoryTranslations.Lang" 
            });

            if (category==null)
            {
                throw new Exception("Category not found!");
            }

            category.Order=request.Order;
            category.Status=request.Status;
            category.ParentId=request.ParentId;
            category.Image1=request.Image1;

            var existingTranslations=category.CategoryTranslations.ToList();

            foreach (var existingTranslation in existingTranslations)
            {
                if (!request.CategoryTranslations.Any(t=>t.LangId == existingTranslation.LangId))
                {
                    category.CategoryTranslations.Remove(existingTranslation);
                }
            }

            foreach (var translationDTO in request.CategoryTranslations)
            {
                var translation=existingTranslations.FirstOrDefault(t=>t.LangId == translationDTO.LangId);
                if (translation==null)
                {
                    translation=new CategoryTranslation();
                    category.CategoryTranslations.Add(translation);
                }
                _mapper.Map(translationDTO,translation);
            }

            _categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveAsync();

            return new UpdateCategoryCommandResponse();          
        }
    }
}
