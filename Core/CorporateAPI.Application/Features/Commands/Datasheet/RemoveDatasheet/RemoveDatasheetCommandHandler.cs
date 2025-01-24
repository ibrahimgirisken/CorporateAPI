using AutoMapper;
using CorporateAPI.Application.Repositories.Datasheet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Datasheet.RemoveDatasheet
{
    public class RemoveDatasheetCommandHandler : IRequestHandler<RemoveDatasheetCommandRequest, RemoveDatasheetCommandResponse>
    {
        readonly IDatasheetWriteRepository _datasheetWriteRepository;
        readonly IMapper _mapper;

        public RemoveDatasheetCommandHandler(IDatasheetWriteRepository datasheetWriteRepository, IMapper mapper)
        {
            _datasheetWriteRepository = datasheetWriteRepository;
            _mapper = mapper;
        }

        public async Task<RemoveDatasheetCommandResponse> Handle(RemoveDatasheetCommandRequest request, CancellationToken cancellationToken)
        {
            await _datasheetWriteRepository.RemoveAsync(request.Id);
            await _datasheetWriteRepository.SaveAsync();
            return new();
        }
    }
}
