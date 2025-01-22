using AutoMapper;
using CorporateAPI.Application.DTOs.Product;
using CorporateAPI.Application.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           var products=await _productReadRepository.GetAll(false).Include(e=>e.ProductTranslations).ToListAsync();
            var productsDto=_mapper.Map<List<ResultProductDTO>>(products);
            return new()
            {
                ProductsDto = productsDto,
            };
        }
    }
}
