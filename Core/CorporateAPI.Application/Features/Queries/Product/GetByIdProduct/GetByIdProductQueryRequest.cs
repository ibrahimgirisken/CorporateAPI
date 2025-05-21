using MediatR;

namespace CorporateAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryRequest:IRequest<GetByIdProductQueryResponse>
    {
        public string Id { get; set; }
        public string? Language { get; set; }
        public bool IncludeAllLanguages { get; set; } = false;
    }
}
