using AutoMapper;
using CorporateAPI.Application.DTOs.Product;
using CorporateAPI.Application.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            if (string.IsNullOrWhiteSpace(request.Url))
                return new() { ProductDTO = null };

            var product = await _productReadRepository.GetSingleAsync(e=>e.ProductTranslations.Any(t=>t.Url==request.Url),
                tracking:false,
                include:q=>q
                .Include(e=>e.ProductTranslations)
                .ThenInclude(t=>t.Lang));


            if (product is null)
                return new() { ProductDTO = null };

            var dto = _mapper.Map<ResultProductDTO>(product);
            return new() { ProductDTO = dto };
        }
    }
}
