using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.UpdatePage
{
    public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommandRequest, UpdatePageCommandResponse>
    {
        readonly IPageWriteRepository _pageWriteRepository;
        readonly IPageReadRepository _pageReadRepository;

        public UpdatePageCommandHandler(IPageWriteRepository pageWriteRepository, IPageReadRepository pageReadRepository)
        {
            _pageWriteRepository = pageWriteRepository;
            _pageReadRepository = pageReadRepository;
        }

        public async Task<UpdatePageCommandResponse> Handle(UpdatePageCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Page page = await _pageReadRepository.GetByIdAsync(request.Id);
            page.Content=request.Content;
            page.Title=request.Title;
            page.Slug=request.Slug;
            _pageWriteRepository.Update(page);
            _pageWriteRepository.SaveAsync();
            return new();
        }
    }
}
