using AutoMapper;
using CorporateAPI.Application.DTOs.Home;
using CorporateAPI.Application.Repositories.Home;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CorporateAPI.Application.Features.Queries.Home.GetAllHome
{
    public class GetAllHomeQueryHandler : IRequestHandler<GetAllHomeQueryRequest, GetAllHomeQueryResponse>
    {
        readonly IHomeReadRepository _homeReadRepository;
        readonly IMapper _mapper;
        public GetAllHomeQueryHandler(IHomeReadRepository homeReadRepository, IMapper mapper)
        {
            _homeReadRepository = homeReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllHomeQueryResponse> Handle(GetAllHomeQueryRequest request, CancellationToken cancellationToken)
        {

            if (request.IncludeAllLanguages)
            {
                var homeTranslations = _homeReadRepository.GetAll(false).Include(e => e.HomeTranslations).ThenInclude(l=>l.Lang).ToList();
                var homeDatas = _mapper.Map<List<ResultHomeDTO>>(homeTranslations);
                return new()
                {
                    Homes = homeDatas
                };
            }
            var language = request.Language ?? "en";
            var homesFiltered = _homeReadRepository.GetAll(false)
                   .Include(e => e.HomeTranslations)
                       .ThenInclude(t => t.Lang)
                   .ToList();
            foreach (var home in homesFiltered)
            {
                home.HomeTranslations = home.HomeTranslations
                    .Where(t => t.Lang.LangCode == language)
                    .ToList();
            }

            var filteredHomeDtos = _mapper.Map<List<ResultHomeDTO>>(homesFiltered);
            return new() { Homes = filteredHomeDtos };
        }
    }
}
