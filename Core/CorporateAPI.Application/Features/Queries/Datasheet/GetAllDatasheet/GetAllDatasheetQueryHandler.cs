using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.DTOs.Datasheet;
using CorporateAPI.Application.Repositories.Banner;
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

            if (request.IncludeAllLanguages)
            {
                var datasheetTranslations = _datasheetReadRepository.GetAll(false).Include(e => e.DatasheetTranslations).ThenInclude(l=>l.Lang).ToList();
                var datasheetDatas = _mapper.Map<List<ResultDatasheetDTO>>(datasheetTranslations);
                return new()
                {
                    resultDatasheetsDto = datasheetDatas
                };
            }
            var language = request.Language ?? "en";
            var datasheetsFiltered = _datasheetReadRepository.GetAll(false)
                   .Include(e => e.DatasheetTranslations)
                       .ThenInclude(t => t.Lang)
                   .ToList();
            foreach (var datasheet in datasheetsFiltered)
            {
                datasheet.DatasheetTranslations = datasheet.DatasheetTranslations
                    .Where(t => t.Lang.LangCode == language)
                    .ToList();
            }

            var filteredBannerDtos = _mapper.Map<List<ResultDatasheetDTO>>(datasheetsFiltered);
            return new() { resultDatasheetsDto = filteredBannerDtos };

        }
    }
}
