using MediatR;

namespace CorporateAPI.Application.Features.Queries.Product.GetByUrlProduct
{
    public class GetByUrlProductQueryRequest:IRequest<GetByUrlProductQueryResponse>
    {
        public string Url { get; set; }
        public string? Language { get; set; }
    }
}