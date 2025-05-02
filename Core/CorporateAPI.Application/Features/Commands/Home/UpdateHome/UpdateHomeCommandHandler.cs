using AutoMapper;
using CorporateAPI.Application.Repositories.Home;
using CorporateAPI.Domain.Entities.Home;
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

            if (home == null)
                throw new Exception("Home not found!");

            home.Order = request.Order;
            home.Status = request.Status;
            home.ContentType = request.ContentType;
            home.Image1 = request.Image1;
            home.Image2 = request.Image2;
            home.Image3 = request.Image3;
            home.Image4 = request.Image4;
            home.Image5 = request.Image5;
            home.Video = request.Video;

            var existingTranslations = home.HomeTranslations.ToList();

            foreach (var existingTranslation in existingTranslations)
            {
                if (!request.HomeTranslations.Any(t=>t.LangId == existingTranslation.LangId))
                {
                    home.HomeTranslations.Remove(existingTranslation);
                }  
            }

            foreach (var translationDTO in request.HomeTranslations)
            {
                var translation = existingTranslations.FirstOrDefault(t => t.LangId == translationDTO.LangId);
                if (translation == null)
                {
                    translation = new HomeTranslation();
                    home.HomeTranslations.Add(translation);
                }
                _mapper.Map(translationDTO, translation);
            }

            _homeWriteRepository.Update(home);
            await _homeWriteRepository.SaveAsync();
            return new();
        }
    }
}
