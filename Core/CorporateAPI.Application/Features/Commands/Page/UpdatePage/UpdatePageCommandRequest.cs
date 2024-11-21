using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.UpdatePage
{
    public class UpdatePageCommandRequest:IRequest<UpdatePageCommandResponse>
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public Guid? MenuId  { get; set; }
    }
}
