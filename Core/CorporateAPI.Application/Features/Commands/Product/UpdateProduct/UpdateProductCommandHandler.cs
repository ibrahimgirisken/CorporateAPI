using AutoMapper;
using CorporateAPI.Application.Repositories.Product;
using CorporateAPI.Domain.Entities.Product;
using MediatR;

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
           var product= await _productReadRepository.GetByIdAsync(request.Id,false,includes:e=>e.ProductTranslations);
            if (product == null)
                throw new Exception("Ürün Bulunamadı");
            _mapper.Map(request,product);
            foreach (var translationDto in request.ProductTranslations)
            {
                var existingTranslation=product.ProductTranslations.FirstOrDefault(t=>t.Locale==translationDto.Locale);
                if (existingTranslation != null)
                {
                    _mapper.Map(translationDto, existingTranslation);
                }
                else
                {
                    var newTranslation=_mapper.Map<ProductTranslation>(translationDto);
                    product.ProductTranslations.Add(newTranslation);
                }
            }
            _productWriteRepository.Update(product);
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
