using AutoMapper;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
using MediatR;


namespace CorporateAPI.Application.Features.Commands.Page.CreatePage
{
    public class CreatePageCommandHandler : IRequestHandler<CreatePageCommandRequest, CreatePageCommandResponse>
    {
        readonly IPageWriteRepository _pageWriteRepository;
        readonly IMapper _mapper;

        public CreatePageCommandHandler(IPageWriteRepository pageWriteRepository, IMapper mapper = null)
        {
            _pageWriteRepository = pageWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreatePageCommandResponse> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page = _mapper.Map<Domain.Entities.Page.Page>(request);
           if (request.PageTranslations != null)
            {
               page.PageTranslations=_mapper.Map<List<PageTranslation>>(request.PageTranslations);
            }
            await _pageWriteRepository.AddAsync(page);
            await _pageWriteRepository.SaveAsync();
            return new();
        }
    }
}
