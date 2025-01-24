using AutoMapper;
using CorporateAPI.Application.Repositories.Datasheet;
using CorporateAPI.Domain.Entities.Datasheet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Datasheet.CreateDatasheet
{
    public class CreateDatasheetCommandHandler : IRequestHandler<CreateDatasheetCommandRequest, CreateDatasheetCommandResponse>
    {
        readonly IDatasheetWriteRepository _datasheetWriteRepository;
        readonly IMapper _mapper;

        public CreateDatasheetCommandHandler(IDatasheetWriteRepository datasheetWriteRepository, IMapper mapper)
        {
            _datasheetWriteRepository = datasheetWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateDatasheetCommandResponse> Handle(CreateDatasheetCommandRequest request, CancellationToken cancellationToken)
        {
            var datasheet= _mapper.Map<Domain.Entities.Datasheet.Datasheet>(request);
            if (request.DatasheetTranslations != null) 
            { 
                datasheet.DatasheetTranslations=_mapper.Map<List<DatasheetTranslation>>(request.DatasheetTranslations);
            }
            await _datasheetWriteRepository.AddAsync(datasheet);
            await _datasheetWriteRepository.SaveAsync();
            return new();
        }
    }
}
