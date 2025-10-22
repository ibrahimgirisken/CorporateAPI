using MediatR;

namespace CorporateAPI.Application.Features.Queries.Module.GetByIdModule
{
    public class GetByIdModuleQueryRequest:IRequest<GetByIdModuleQueryResponse>
    {
        public string Id { get; set; }
    }
}
