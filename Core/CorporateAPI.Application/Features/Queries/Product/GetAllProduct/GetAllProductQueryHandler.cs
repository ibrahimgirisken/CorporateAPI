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

            var produtTranslations = _productReadRepository.GetAll(false).Include(e => e.ProductTranslations).ThenInclude(l => l.Lang).ToList();
            var pageDatas = _mapper.Map<List<ResultProductDTO>>(produtTranslations);
            return new()
            {
                ProductsDto = pageDatas
            };

        }
    }
}
