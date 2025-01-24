using AutoMapper;
using CorporateAPI.Application.Repositories.Category;
using CorporateAPI.Domain.Entities.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var existingTranslations= category.CategoryTranslations.ToList();
            category.Image1=request.Image1;
            category.Status=request.Status;
            category.Order=request.Order;
            category.ParentId=request.ParentId;
            category.CategoryTranslations.Clear();

            foreach (var translationDTO in request.CategoryTranslations)
            {
                var translation=existingTranslations.FirstOrDefault(t=>t.Locale==translationDTO.Locale) ?? new CategoryTranslation();
                _mapper.Map(translationDTO, translation);
                category.CategoryTranslations.Add(translation);
            }
            _categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}
