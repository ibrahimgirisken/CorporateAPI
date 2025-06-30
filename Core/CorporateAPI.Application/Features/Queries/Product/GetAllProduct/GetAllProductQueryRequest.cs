using MediatR;

namespace CorporateAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequest:IRequest<GetAllProductQueryResponse>
    {
        public string? Language { get; set; }
        public bool IncludeAllLanguages { get; set; } = false;
    }
}
