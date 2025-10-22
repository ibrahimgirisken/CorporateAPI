using MediatR;

namespace CorporateAPI.Application.Features.Queries.Home.GetByIdHome
{
    public class GetByIdHomeQueryRequest:IRequest<GetByIdHomeQueryResponse>
    {
        public string Id { get; set; }
    }
}
