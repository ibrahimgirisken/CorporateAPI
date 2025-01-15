using AutoMapper;
using CorporateAPI.Application.Repositories.Home;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var home=await _homeReadRepository.GetByIdAsync(request.HomeDTO.Id,false,includes:e=>e.HomeTranslations);
            var existingTranslations = home.HomeTranslations.ToList();
            var homeData=_mapper.Map<Domain.Entities.Home.Home>(home);
            home.HomeTranslations.Clear();
            foreach (var item in existingTranslations)
            {
                var translsation = existingTranslations.FirstOrDefault(t => t.Locale == item.Locale) ?? new Domain.Entities.Home.HomeTranslation();
            }
            _homeWriteRepository.Update(home);
            await _homeWriteRepository.SaveAsync();
            return new();
        }
    }
}
