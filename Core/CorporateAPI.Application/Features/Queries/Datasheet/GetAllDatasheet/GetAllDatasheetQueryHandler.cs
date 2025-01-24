using AutoMapper;
using CorporateAPI.Application.DTOs.Datasheet;
using CorporateAPI.Application.Repositories.Datasheet;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var datasheets=_datasheetReadRepository.GetAll(false).Include(e => e.DatasheetTranslations).ToListAsync();
            var datasheetsDto=_mapper.Map<List<ResultDatasheetDTO>>(datasheets);
            return new()
            {
                resultDatasheetsDto = datasheetsDto,
            };
        }
    }
}
