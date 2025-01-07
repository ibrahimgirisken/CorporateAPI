using AutoMapper;
using CorporateAPI.Application.DTOs.Lang;
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
        readonly IMapper _mapper;

        public GetAllLangHandler(ILangReadRepository langReadRepository, IMapper mapper)
        {
            _langReadRepository = langReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllLangResponse> Handle(GetAllLangRequest request, CancellationToken cancellationToken)
        {
           var langs= _langReadRepository.GetAll(false).ToList();
           var langDatas= _mapper.Map<List<Domain.Entities.Lang>, List<ResultLangDTO>>(langs);  

            var response = new GetAllLangResponse()
            {
               LangData= langDatas
            };

            return await Task.FromResult(response);

        }
    }
}
