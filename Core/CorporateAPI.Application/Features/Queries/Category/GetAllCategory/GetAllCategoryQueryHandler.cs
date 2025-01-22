using AutoMapper;
using CorporateAPI.Application.DTOs.Category;
using CorporateAPI.Application.Repositories.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
              var categories= _categoryReadRepository.GetAll(false).Include(c=>c.CategoryTranslations).ToList();
            var categoriesDto=_mapper.Map<List<ResultCategoryDTO>>(categories);
            return new()
            {
                CategoriesDto = categoriesDto,
            };
        }
    }
}
