using CorporateAPI.Application.DTOs.Brand;


namespace CorporateAPI.Application.Features.Queries.Brand.GetAllBrand
{
    public class GetAllBrandQueryResponse
    {
        public List<ResultBrandDTO> Brands{ get; set; }
    }
}
