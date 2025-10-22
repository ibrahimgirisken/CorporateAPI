using MediatR;

namespace CorporateAPI.Application.Features.Queries.Page.GetByUrlAddressPage
{
    public class GetByUrlAddressPageQueryRequest:IRequest<GetByUrlAddressPageQueryResponse>
    {
        public string? UrlAddress { get; set; }
    }
}
