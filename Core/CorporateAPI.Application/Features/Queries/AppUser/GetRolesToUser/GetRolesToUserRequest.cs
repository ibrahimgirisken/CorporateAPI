using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.AppUser.GetRolesToUser
{
    public class GetRolesToUserRequest:IRequest<GetRolesToUserResponse>
    {
        public string UserId { get; set; }
    }
}
