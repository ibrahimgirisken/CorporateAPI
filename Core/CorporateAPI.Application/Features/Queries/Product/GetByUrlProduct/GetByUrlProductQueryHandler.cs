using AutoMapper;
using CorporateAPI.Application.DTOs.Product;
using CorporateAPI.Application.Repositories.Product;
using MediatR;

namespace CorporateAPI.Application.Features.Queries.Product.GetByUrlProduct
{
    public class GetByUrlProductQueryHandler : IRequestHandler<GetByUrlProductQueryRequest, GetByUrlProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        readonly IMapper _mapper;
        public GetByUrlProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper = null)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByUrlProductQueryResponse> Handle(GetByUrlProductQueryRequest request, CancellationToken cancellationToken)
        {
            ResultProductDTO productDto = null;

            var product = await _productReadRepository.GetProductByUrlAndLanguageAsync(request.Url, request.Language);

            if (product != null)
            {
                product.ProductTranslations = product.ProductTranslations
                    .Where(t => t.Lang.LangCode == request.Language)
                    .ToList();
                productDto = _mapper.Map<ResultProductDTO>(product);
            }
            return new()
            {
                ProductDTO = productDto
            };
        }
    }
}
