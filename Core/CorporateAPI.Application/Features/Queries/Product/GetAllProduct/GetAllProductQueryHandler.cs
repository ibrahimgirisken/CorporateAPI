using AutoMapper;
using CorporateAPI.Application.DTOs.Product;
using CorporateAPI.Application.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CorporateAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {

            if (request.IncludeAllLanguages)
            {
                var productTranslations = _productReadRepository.GetAll(false).Include(e => e.ProductTranslations).ThenInclude(l => l.Lang).ToList();
                var productDatas = _mapper.Map<List<ResultProductDTO>>(productTranslations);
                return new()
                {
                    ProductsDto = productDatas
                };
            }
            var language = request.Language ?? "en";
            var productsFiltered = _productReadRepository.GetAll(false)
                   .Include(e => e.ProductTranslations)
                       .ThenInclude(t => t.Lang)
                   .ToList();
            foreach (var product in productsFiltered)
            {
                product.ProductTranslations = product.ProductTranslations
                    .Where(t => t.Lang.LangCode == language)
                    .ToList();
            }

            var filteredProductDtos = _mapper.Map<List<ResultProductDTO>>(productsFiltered);
            return new() { ProductsDto = filteredProductDtos };

        }
    }
}
