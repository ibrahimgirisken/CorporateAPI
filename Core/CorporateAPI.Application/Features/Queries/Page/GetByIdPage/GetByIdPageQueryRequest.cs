using MediatR;

namespace CorporateAPI.Application.Features.Queries.Page.GetByIdPage
{
    public class GetByIdPageQueryRequest:IRequest<GetByIdPageQueryResponse>
    {
        public string Id { get; set; }
    }
}
