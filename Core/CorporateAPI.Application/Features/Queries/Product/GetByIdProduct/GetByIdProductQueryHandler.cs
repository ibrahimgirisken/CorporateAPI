using AutoMapper;
using CorporateAPI.Application.DTOs.Product;
using CorporateAPI.Application.Repositories.Product;
using MediatR;
using System.Linq.Expressions;

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
            var product=await _productReadRepository.GetByIdAsync(request.Id,false,includes:new Expression<Func<Domain.Entities.Product.Product,object>>[]{
                e=>e.ProductTranslations
            },includeStrings:new[]
                {
                    "ProductTranslations.Lang"
                }
            );
            var productDto=_mapper.Map<ResultProductDTO>(product);
            return new()
            {
                ProductDTO = productDto
            };
        }
    }
}
