using CorporateAPI.Application.DTOs.Product;

namespace CorporateAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public List<ResultProductDTO> ProductsDto{ get; set; }
    }
}
