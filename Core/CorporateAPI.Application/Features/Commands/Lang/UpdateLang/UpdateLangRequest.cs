using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.UpdateLang
{
    public class UpdateLangRequest:IRequest<UpdateLangResponse>
    {
        public int Id { get; set; }
        public string LangCode { get; set; }
    }
}
