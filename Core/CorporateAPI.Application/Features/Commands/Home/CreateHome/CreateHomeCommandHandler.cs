using AutoMapper;
using CorporateAPI.Application.Repositories.Home;
using CorporateAPI.Domain.Entities.Home;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Home.CreateHome
{
    public class CreateHomeCommandHandler : IRequestHandler<CreateHomeCommandRequest, CreateHomeCommandResponse>
    {
        readonly IHomeWriteRepository _homeWriteRepository;
        readonly IMapper _mapper;

        public CreateHomeCommandHandler(IMapper mapper, IHomeWriteRepository homeWriteRepository)
        {
            _mapper = mapper;
            _homeWriteRepository = homeWriteRepository;
        }

        public async Task<CreateHomeCommandResponse> Handle(CreateHomeCommandRequest request, CancellationToken cancellationToken)
        {
            var home = _mapper.Map<Domain.Entities.Home.Home>(request);
            if (request.HomeTranslations != null)
            {
                home.HomeTranslations=_mapper.Map<List<HomeTranslation>>(request.HomeTranslations);
            }
            await _homeWriteRepository.AddAsync(home);
            await _homeWriteRepository.SaveAsync();
            return new();
           
        }
    }
}
