using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.CreateLang
{
    public class CreateLangHandler : IRequestHandler<CreateLangRequest, CreateLangResponse>
    {
        public Task<CreateLangResponse> Handle(CreateLangRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
