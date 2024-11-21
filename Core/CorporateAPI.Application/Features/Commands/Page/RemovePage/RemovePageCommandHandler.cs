using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.RemovePage
{
    public class RemovePageCommandHandler : IRequestHandler<RemovePageCommandRequest, RemovePageCommandResponse>
    {
        readonly IPageWriteRepository _pageWriteRepository;

        public RemovePageCommandHandler(IPageWriteRepository pageWriteRepository)
        {
            _pageWriteRepository = pageWriteRepository;
        }

        public async Task<RemovePageCommandResponse> Handle(RemovePageCommandRequest request, CancellationToken cancellationToken)
        {
            await _pageWriteRepository.RemoveAsync(request.Id);
            await _pageWriteRepository.SaveAsync();
            return new();

        }
    }
}
