using AutoMapper;
using CorporateAPI.Application.Repositories.Datasheet;
using CorporateAPI.Domain.Entities.Datasheet;
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
            _datasheetReadRepository = datasheetReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateDatasheetCommandResponse> Handle(UpdateDatasheetCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Datasheet.Datasheet datasheet=await _datasheetReadRepository.GetByIdAsync(request.Id,false,includes:e=>e.DatasheetTranslations);
            if (datasheet == null)
                throw new Exception("Datasheet not found!");

            datasheet.Order=request.Order;
            datasheet.Code=request.Code;
            datasheet.Status = request.Status;
            datasheet.Image1 = request.Image1;

            var existingTranslations = datasheet.DatasheetTranslations.ToList();

            foreach (var existingTranslation in existingTranslations)
            {
                if (!request.DatasheetTranslations.Any(t => t.Locale == existingTranslation.Locale))
                {
                    datasheet.DatasheetTranslations.Remove(existingTranslation);
                }
            }

            foreach (var translationDTO in request.DatasheetTranslations)
            {
                var translation = existingTranslations.FirstOrDefault(t => t.Locale == translationDTO.Locale);
                if (translation == null)
                {
                    translation = new DatasheetTranslation();
                    datasheet.DatasheetTranslations.Add(translation);
                }
                _mapper.Map(translationDTO, translation);
            }

            _datasheetWriteRepository.Update(datasheet);
            await _datasheetWriteRepository.SaveAsync();
            return new();
        }
    }
}
