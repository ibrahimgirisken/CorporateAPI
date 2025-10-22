using MediatR;

namespace CorporateAPI.Application.Features.Queries.Role.GetAllRole
{
    public class GetAllRoleQueryRequest:IRequest<GetAllRoleQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
