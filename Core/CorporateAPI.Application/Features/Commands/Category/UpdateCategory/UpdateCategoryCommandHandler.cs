using AutoMapper;
using CorporateAPI.Application.Repositories.Category;
using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.Domain.Entities.Category;
using MediatR;
using System.Reflection;

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
            Domain.Entities.Category.Category category=await _categoryReadRepository.GetByIdAsync(request.Id,false,e=>e.CategoryTranslations);


            if (category == null)
                throw new Exception("Category not found!");

            category.CategoryTranslations.Clear();
            category.Image1=request.Image1;
            category.Order=request.Order;
            category.Status=request.Status;
            category.ParentId=request.ParentId;

            var existingTranslations= category.CategoryTranslations.ToList();

            foreach (var existingTranslation in existingTranslations)
            {
                if (!request.CategoryTranslations.Any(t => t.Locale == existingTranslation.Locale))
                {
                    category.CategoryTranslations.Remove(existingTranslation);
                }
            }

            foreach (var translationDTO in request.CategoryTranslations)
            {
                var translation = existingTranslations.FirstOrDefault(t => t.Locale == translationDTO.Locale);
                if (translation == null)
                {
                    translation = new CategoryTranslation();
                    category.CategoryTranslations.Add(translation);
                }
                _mapper.Map(translationDTO, translation);
            }

            _categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}
