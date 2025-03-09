using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.AppUser.GetRolesToUser
{
    public class GetRolesToUserHandler : IRequestHandler<GetRolesToUserRequest, GetRolesToUserResponse>
    {
        Task<GetRolesToUserResponse> IRequestHandler<GetRolesToUserRequest, GetRolesToUserResponse>.Handle(GetRolesToUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
