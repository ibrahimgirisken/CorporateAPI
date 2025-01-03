using CorporateAPI.Application.DTOs.Page;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.CreatePage
{
    public class CreatePageCommandRequest:IRequest<CreatePageCommandResponse>
    {
        public CreatePageDTO PageDto{ get; set; }
    }
}
