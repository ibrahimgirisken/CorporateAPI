using MediatR;

namespace CorporateAPI.Application.Features.Queries.Menu.GetAllMenu
{
    public class GetAllMenuQueryRequest:IRequest<GetAllMenuQueryResponse>
    {
        public string? Language { get; set; }
        public bool IncludeAllLanguages { get; set; } = false;
    }
}