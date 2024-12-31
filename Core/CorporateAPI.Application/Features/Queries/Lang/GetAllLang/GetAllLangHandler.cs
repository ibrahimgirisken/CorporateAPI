using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Lang.GetAllLang
{
    public class GetAllLangHandler : IRequestHandler<GetAllLangRequest, GetAllLangResponse>
    {
        readonly ILangReadRepository _langReadRepository;

        public GetAllLangHandler(ILangReadRepository langReadRepository)
        {
            _langReadRepository = langReadRepository;
        }

        public async Task<GetAllLangResponse> Handle(GetAllLangRequest request, CancellationToken cancellationToken)
        {
           var langs= _langReadRepository.GetAll(false).ToList();
            var response = new GetAllLangResponse()
            {
               LangData=langs
            };

            return await Task.FromResult(response);

        }
    }
}
