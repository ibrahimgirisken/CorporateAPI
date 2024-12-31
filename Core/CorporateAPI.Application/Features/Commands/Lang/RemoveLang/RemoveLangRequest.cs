using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.RemoveLang
{
    public class RemoveLangRequest:IRequest<RemoveLangResponse>
    {
        public int Id { get; set; }
    }
}
