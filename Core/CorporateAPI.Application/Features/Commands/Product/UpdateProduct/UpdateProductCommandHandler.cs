using AutoMapper;
using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Application.Helpers;
using CorporateAPI.Application.Repositories.Product;
using MediatR;
using System.Linq.Expressions;

namespace CorporateAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IMapper _mapper;
        readonly ILanguageCodeResolverService _langService;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper, ILanguageCodeResolverService langService = null)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
            _langService = langService;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product.Product product = await _productReadRepository.GetByIdAsync(request.Id, false, includes: new Expression<Func<Domain.Entities.Product.Product, object>>[]
            {
                e => e.ProductTranslations
            });

            if (product == null)
                throw new Exception("Product not found!");

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

            TranslationHelper.UpdateOrAddTranslations(
                product.ProductTranslations,
                request.ProductTranslations,
                dto=>dto.LangCode,
                code=>_langService.GetLangIdByLangCode(code),
                (dto,entity)=>_mapper.Map(dto, entity));

           _productWriteRepository.Update(product);
            await _productWriteRepository.SaveAsync();

            return new UpdateProductCommandResponse();
        }
    }
}
