using AutoMapper;
using CorporateAPI.Application.Repositories.Product;
using CorporateAPI.Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
           var product= await _productReadRepository.GetByIdAsync(request.Id);
            if (product.ProductTranslations != null)
            {
                product.ProductTranslations = _mapper.Map<List<ProductTranslation>>(request.ProductTranslations);
            }
            _productWriteRepository.Update(product);
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
