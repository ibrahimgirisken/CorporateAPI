using AutoMapper;
using CorporateAPI.Application.DTOs.Datasheet;
using CorporateAPI.Application.Repositories.Datasheet;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CorporateAPI.Application.Features.Queries.Datasheet.GetAllDatasheet
{
    public class GetAllDatasheetQueryHandler : IRequestHandler<GetAllDatasheetQueryRequest, GetAllDatasheetQueryResponse>
    {
        readonly IDatasheetReadRepository _datasheetReadRepository;
        readonly IMapper _mapper;

        public GetAllDatasheetQueryHandler(IDatasheetReadRepository datasheetReadRepository, IMapper mapper)
        {
            _datasheetReadRepository = datasheetReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllDatasheetQueryResponse> Handle(GetAllDatasheetQueryRequest request, CancellationToken cancellationToken)
        {
            var pageTranslations = _datasheetReadRepository.GetAll(false).Include(e => e.DatasheetTranslations).ThenInclude(l => l.Lang).ToList();
            var datasheetDatas = _mapper.Map<List<ResultDatasheetDTO>>(pageTranslations);
            return new()
            {
                resultDatasheetsDto = datasheetDatas
            };

        }
    }
}
