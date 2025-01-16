using AutoMapper;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Page.UpdatePage
{
    public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommandRequest, UpdatePageCommandResponse>
    {
        readonly IPageWriteRepository _pageWriteRepository;
        readonly IPageReadRepository _pageReadRepository;
        readonly IMapper _mapper;

        public UpdatePageCommandHandler(IPageWriteRepository pageWriteRepository, IPageReadRepository pageReadRepository, IMapper mapper = null)
        {
            _pageWriteRepository = pageWriteRepository;
            _pageReadRepository = pageReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePageCommandResponse> Handle(UpdatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page = await _pageReadRepository.GetByIdAsync(request.Id, false, includes: e => e.PageTranslations);
            foreach (var translsationDto in request.PageTranslations)
            {
                var existingTranslsation=page.PageTranslations.FirstOrDefault(t=>t.Locale == translsationDto.Locale);
                if (existingTranslsation!=null)
                {
                    _mapper.Map(translsationDto, existingTranslsation);
                }
                else
                {
                    var newTranslsation=_mapper.Map<PageTranslation>(translsationDto);
                    page.PageTranslations.Add(newTranslsation);
                }
            }
            _pageWriteRepository.Update(page);
            await _pageWriteRepository.SaveAsync();
            return new();
        }
    }
}
