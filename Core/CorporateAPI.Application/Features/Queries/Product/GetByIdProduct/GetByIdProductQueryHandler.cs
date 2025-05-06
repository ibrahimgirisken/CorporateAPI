using AutoMapper;
using CorporateAPI.Application.DTOs.Product;
using CorporateAPI.Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id, false,
                includes: new Expression<Func<Domain.Entities.Product.Product, object>>[]
                {
                e => e.ProductTranslations,
                c => c.Category,
                b => b.Brand
                },
                includeStrings: new[]
                {
                    "ProductTranslations.Lang",
                    "Category.CategoryTranslations.Lang",
                    "Brand.BrandTranslations.Lang"
                });

            var productDto = _mapper.Map<ResultProductDTO>(product);
            return new()
            {
                ProductDTO = productDto
            };
        }
    }
}
