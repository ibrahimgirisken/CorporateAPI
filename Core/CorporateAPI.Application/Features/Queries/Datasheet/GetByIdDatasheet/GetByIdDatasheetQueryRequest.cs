using MediatR;

namespace CorporateAPI.Application.Features.Queries.Datasheet.GetByIdDatasheet
{
    public class GetByIdDatasheetQueryRequest:IRequest<GetByIdDatasheetQueryResponse>
    {
        public string Id { get; set; }
    }
}
