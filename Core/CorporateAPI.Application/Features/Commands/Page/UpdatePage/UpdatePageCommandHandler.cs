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
            Domain.Entities.Page.Page page = await _pageReadRepository.GetByIdAsync(request.Id, false, includes: e => e.PageTranslations);
           
            if (page == null)
                throw new Exception("Page not found!");
            
            page.Order = request.Order;
            page.Status = request.Status;
            page.ModuleIds = request.ModuleIds;
            page.Image1 = request.Image1;
            page.Image2 = request.Image2;
            page.Image3 = request.Image3;


            var existingTranslations = page.PageTranslations.ToList();

            foreach (var existingTranslation in existingTranslations)
            {
                if (!request.PageTranslations.Any(t => t.Locale == existingTranslation.Locale))
                {
                    page.PageTranslations.Remove(existingTranslation);
                }
            }

            foreach (var translationDTO in request.PageTranslations)
            {
                var translation = existingTranslations.FirstOrDefault(t => t.Locale == translationDTO.Locale);
                if (translation == null)
                {
                    translation = new PageTranslation();
                    page.PageTranslations.Add(translation);
                }
                _mapper.Map(translationDTO, translation);
            }

            _pageWriteRepository.Update(page);
            await _pageWriteRepository.SaveAsync();

            return new UpdatePageCommandResponse();
        }
    }
}
