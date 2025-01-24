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

        public UpdatePageCommandHandler(IPageWriteRepository pageWriteRepository, IPageReadRepository pageReadRepository, IMapper mapper)
        {
            _pageWriteRepository = pageWriteRepository;
            _pageReadRepository = pageReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePageCommandResponse> Handle(UpdatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page = await _pageReadRepository.GetByIdAsync(request.Id, false, includes: e => e.PageTranslations);
            page.PageTranslations.Clear();
            var existinTranslations=page.PageTranslations.ToList();
            page.Order=request.Order;
            page.Image1=request.Image1;
            page.Image2=request.Image2;
            page.Image3=request.Image3;
            page.Status = request.Status;
            page.ModuleIds=request.ModuleIds;

            foreach (var translationDTO in existinTranslations)
            {
                var translation = existinTranslations.FirstOrDefault(t => t.Locale == translationDTO.Locale) ?? new PageTranslation();
                _mapper.Map(translationDTO, translation);
                page.PageTranslations.Add(translation);
            }

            _pageWriteRepository.Update(page);
            await _pageWriteRepository.SaveAsync();
            return new();
        }
    }
}
