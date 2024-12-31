using AutoMapper;
using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Lang.GetByIdLang
{
    public class GetByIdLangHandler : IRequestHandler<GetByIdLangRequest, GetByIdLangResponse>
    {
        readonly ILangReadRepository _langReadRepository;
        readonly IMapper _mapper;

        public GetByIdLangHandler(ILangReadRepository langReadRepository, IMapper mapper)
        {
            _langReadRepository = langReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdLangResponse> Handle(GetByIdLangRequest request, CancellationToken cancellationToken)
        {
          var lang= _mapper.Map<Domain.Entities.Lang>(await _langReadRepository.GetByIdAsync(request.Id, false));
            return new()
            {
                Lang = lang
            };
        }
    }
}
