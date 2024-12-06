using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.RemovePage
{
    public class RemovePageCommandRequest:IRequest<RemovePageCommandResponse>
    {
        public int Id { get; set; }
    }
}
