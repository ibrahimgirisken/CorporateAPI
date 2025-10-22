using MediatR;

namespace CorporateAPI.Application.Features.Queries.AppUser.GetRolesToUser
{
    public class GetRolesToUserRequest:IRequest<GetRolesToUserResponse>
    {
        public string UserId { get; set; }
    }
}
