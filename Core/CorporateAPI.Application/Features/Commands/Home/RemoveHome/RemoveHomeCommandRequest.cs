using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Home.RemoveHome
{
    public class RemoveHomeCommandRequest:IRequest<RemoveHomeCommandResponse>
    {
    }
}
