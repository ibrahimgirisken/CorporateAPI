using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.CreatePage
{
    public class CreatePageCommandHandler : IRequestHandler<CreatePageCommandRequest, CreatePageCommandResponse>
    {
        readonly IPageWriteRepository _pageWriteRepository;

        public CreatePageCommandHandler(IPageWriteRepository pageWriteRepository)
        {
            _pageWriteRepository = pageWriteRepository;
        }

        public async Task<CreatePageCommandResponse> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            await _pageWriteRepository.AddAsync(new()
            {
                Content = request.Content,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            await _pageWriteRepository.SaveAsync();
            return new();
        }
    }
}
