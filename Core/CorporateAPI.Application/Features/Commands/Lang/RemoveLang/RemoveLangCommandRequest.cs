using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.RemoveLang
{
    public class RemoveLangCommandRequest:IRequest<RemoveLangCommandResponse>
    {
        public int Id { get; set; }
    }
}
