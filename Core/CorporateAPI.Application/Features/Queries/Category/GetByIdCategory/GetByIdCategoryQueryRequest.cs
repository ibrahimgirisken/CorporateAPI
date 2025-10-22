using MediatR;

namespace CorporateAPI.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest:IRequest<GetByIdCategoryQueryResponse>
    {
        public string Id { get; set; }
    }
}
