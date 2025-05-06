using AutoMapper;
using CorporateAPI.Application.DTOs.Datasheet;
using CorporateAPI.Application.Repositories.Datasheet;
using MediatR;
using System.Linq.Expressions;

namespace CorporateAPI.Application.Features.Queries.Datasheet.GetByIdDatasheet
{
    public class GetByIdDatasheetQueryHandler : IRequestHandler<GetByIdDatasheetQueryRequest, GetByIdDatasheetQueryResponse>
    {
        readonly IDatasheetReadRepository _datasheetReadRepository;
        readonly IMapper _mapper;

        public GetByIdDatasheetQueryHandler(IDatasheetReadRepository datasheetReadRepository, IMapper mapper)
        {
            _datasheetReadRepository = datasheetReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdDatasheetQueryResponse> Handle(GetByIdDatasheetQueryRequest request, CancellationToken cancellationToken)
        {
            var datasheet= await _datasheetReadRepository.GetByIdAsync(request.Id, false,includes:new Expression<Func<Domain.Entities.Datasheet.Datasheet, object>>[]
            {
                e => e.DatasheetTranslations
            },
            includeStrings: new[]
            {
                "DatasheetTranslations.Lang"
            });
            var ResultDatasheet= _mapper.Map<ResultDatasheetDTO>(datasheet);
            return new()
            {
                ResultDatasheetDTO = ResultDatasheet,
            };
        }
    }
}
