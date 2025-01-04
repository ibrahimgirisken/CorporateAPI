using CorporateAPI.Application.DTOs.Page;
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
        public int Id { get; set; }
        public UpdatePageDTO PageDTO { get; set; }
    }
}
