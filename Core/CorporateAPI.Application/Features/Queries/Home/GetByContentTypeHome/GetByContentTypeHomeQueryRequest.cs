using MediatR;

namespace CorporateAPI.Application.Features.Queries.Home.GetByContentTypeHome
{
    public class GetByContentTypeHomeQueryRequest:IRequest<GetByContentTypeHomeQueryResponse>
    {

        public string ContentType { get; set; }
        public string? Language { get; set; }
    }
}
