using AutoMapper;
using CorporateAPI.Application.Repositories.Product;
using CorporateAPI.Domain.Entities.Product;
using MediatR;
using System.Linq.Expressions;

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
            Domain.Entities.Product.Product product = await _productReadRepository.GetByIdAsync(request.Id, false, includes: new Expression<Func<Domain.Entities.Product.Product, object>>[]
            {
                e => e.ProductTranslations
            }, includeStrings: new[]
            {
               "ProductTranslations.Lang" });

            if (product == null)
            {
                throw new Exception("Product not found!");
            }

            product.Code = request.Code;
            product.BrandId = request.BrandId;
            product.CategoryId = request.CategoryId;
            product.Image1 = request.Image1;
            product.Image2 = request.Image2;
            product.Image3 = request.Image3;
            product.Image4 = request.Image4;
            product.Image5 = request.Image5;
            product.Video = request.Video;
            product.Order = request.Order;
            product.Status = request.Status;

            var existingTranslations = product.ProductTranslations.ToList();

            foreach (var existingTranslation in existingTranslations)
            {
                if (!request.ProductTranslations.Any(t => t.LangCode == existingTranslation.Lang.LangCode))
                {
                    product.ProductTranslations.Remove(existingTranslation);
                }
            }

            foreach (var translationDTO in request.ProductTranslations)
            {
                var translation = existingTranslations.FirstOrDefault(t => t.Lang.LangCode == translationDTO.LangCode);
                if (translation == null)
                {
                    translation = new ProductTranslation();
                    product.ProductTranslations.Add(translation);
                }
                _mapper.Map(translationDTO, translation);
            }

            _productWriteRepository.Update(product);
            await _productWriteRepository.SaveAsync();

            return new UpdateProductCommandResponse();
        }
    }
}
