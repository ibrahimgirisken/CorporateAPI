using CorporateAPI.Application.DTOs.Lang;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.CreateLang
{
    public class CreateLangRequest:IRequest<CreateLangResponse>
    {
        public CreateLangDTO createLangDTO{ get; set; }
    }
}
