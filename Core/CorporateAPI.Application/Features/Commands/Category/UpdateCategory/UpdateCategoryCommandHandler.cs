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
            var category= await _categoryReadRepository.GetByIdAsync(request.Id);
            if (category.CategoryTranslations != null) 
            {
            category.CategoryTranslations=_mapper.Map<List<CategoryTranslation>>(request.CategoryTranslations);
            }
            _categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}
