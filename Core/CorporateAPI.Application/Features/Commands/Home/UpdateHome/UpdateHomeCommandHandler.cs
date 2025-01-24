using AutoMapper;
using CorporateAPI.Application.Repositories.Home;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Home.UpdateHome
{
    public class UpdateHomeCommandHandler : IRequestHandler<UpdateHomeCommandRequest, UpdateHomeCommandResponse>
    {
        readonly IHomeReadRepository _homeReadRepository;
        readonly IHomeWriteRepository _homeWriteRepository;
        readonly IMapper _mapper;

        public UpdateHomeCommandHandler(IHomeWriteRepository writeRepository, IHomeReadRepository readRepository, IMapper mapper)
        {
            _homeWriteRepository = writeRepository;
            _homeReadRepository = readRepository;
            _mapper = mapper;
        }


        public async Task<UpdateHomeCommandResponse> Handle(UpdateHomeCommandRequest request, CancellationToken cancellationToken)
        {
            var home=await _homeReadRepository.GetByIdAsync(request.Id,false,includes:e=>e.HomeTranslations);
            home.HomeTranslations.Clear();
            var existingTranslsation = home.HomeTranslations.ToList();
            home.Order=request.Order;
            home.Status=request.Status;
            home.ContentType=request.ContentType;

            foreach (var translationDTO in request.HomeTranslations)
            {
                var translation=existingTranslsation.FirstOrDefault(t=>t.Locale==translationDTO.Locale)?? new Domain.Entities.Home.HomeTranslation();
                 _mapper.Map(translationDTO, translation);
                home.HomeTranslations.Add(translation);
            }
            _homeWriteRepository.Update(home);
            await _homeWriteRepository.SaveAsync();
            return new();
        }
    }
}
