using AutoMapper;
using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Application.Helpers;
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
        readonly ILanguageCodeResolverService _langService;

        public UpdateCategoryCommandHandler(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IMapper mapper, ILanguageCodeResolverService langService = null)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
            _langService = langService;
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
                throw new Exception("Category not found!");
            

            category.Order=request.Order;
            category.Status=request.Status;
            category.ParentId=request.ParentId;
            category.Image1=request.Image1;

            TranslationHelper.UpdateOrAddTranslations(
                category.CategoryTranslations,
                request.CategoryTranslations,
                dto => dto.LangCode,
                code => _langService.GetLangIdByLangCode(code),
                (dto, entity) => _mapper.Map(dto, entity)
            );
            _categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveAsync();
            return new UpdateCategoryCommandResponse();          
        }
    }
}
