using AutoMapper;
using CorporateAPI.Application.Repositories.Datasheet;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Datasheet.UpdateDatasheet
{
    public class UpdateDatasheetCommandHandler : IRequestHandler<UpdateDatasheetCommandRequest, UpdateDatasheetCommandResponse>
    {
        readonly IDatasheetWriteRepository _datasheetWriteRepository;
        readonly IDatasheetReadRepository _datasheetReadRepository;
        readonly IMapper _mapper;

        public UpdateDatasheetCommandHandler(IDatasheetWriteRepository datasheetWriteRepository, IMapper mapper, IDatasheetReadRepository datasheetReadRepository)
        {
            _datasheetWriteRepository = datasheetWriteRepository;
            _mapper = mapper;
            _datasheetReadRepository = datasheetReadRepository;
        }

        public async Task<UpdateDatasheetCommandResponse> Handle(UpdateDatasheetCommandRequest request, CancellationToken cancellationToken)
        {
            var datasheet=await _datasheetReadRepository.GetByIdAsync(request.Id,false,includes:e=>e.DatasheetTranslations);
            datasheet.DatasheetTranslations.Clear();
            var existingTranslation=datasheet.DatasheetTranslations.ToList();
            datasheet.Order=request.Order;
            datasheet.Code=request.Code;
            datasheet.Status = request.Status;
            datasheet.Image1 = request.Image1;

            foreach (var translationDTO in existingTranslation)
            {
                var translation = existingTranslation.FirstOrDefault(t => t.Locale == translationDTO.Locale) ?? new Domain.Entities.Datasheet.DatasheetTranslation();
                _mapper.Map(translationDTO, translation);
                datasheet.DatasheetTranslations.Add(translation);
            }

            _datasheetWriteRepository.Update(datasheet);
            await _datasheetWriteRepository.SaveAsync();
            return new();
        }
    }
}
