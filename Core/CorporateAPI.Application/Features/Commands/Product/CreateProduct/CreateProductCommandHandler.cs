using AutoMapper;
using CorporateAPI.Application.Repositories.Product;
using CorporateAPI.Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product=_mapper.Map<Domain.Entities.Product.Product>(request);
            if (product.ProductTranslations != null)
            {
                product.ProductTranslations=_mapper.Map<List<ProductTranslation>>(request.ProductTranslations);
            }
            await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
