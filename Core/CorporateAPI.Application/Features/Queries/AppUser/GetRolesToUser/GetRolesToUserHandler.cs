using CorporateAPI.Application.Abstractions.Services;
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
        readonly IUserService _userService;

        public GetRolesToUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        async Task<GetRolesToUserResponse> IRequestHandler<GetRolesToUserRequest, GetRolesToUserResponse>.Handle(GetRolesToUserRequest request, CancellationToken cancellationToken)
        {
            var userRoles=  await _userService.GetRolesToUserAsync(request.UserId);
            return new()
            {
                UserRoles = userRoles,
            };
        }
    }
}
