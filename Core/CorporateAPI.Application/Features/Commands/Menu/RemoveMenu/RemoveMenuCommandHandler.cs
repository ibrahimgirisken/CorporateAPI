using CorporateAPI.Application.Repositories.Menu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Menu.RemoveMenu
{
    public class RemoveMenuCommandHandler : IRequestHandler<RemoveMenuCommandRequest, RemoveMenuCommandResponse>
    {
        readonly IMenuWriteRepository _menuWriteRepository;

        public RemoveMenuCommandHandler(IMenuWriteRepository menuWriteRepository)
        {
            _menuWriteRepository = menuWriteRepository;
        }

        public async Task<RemoveMenuCommandResponse> Handle(RemoveMenuCommandRequest request, CancellationToken cancellationToken)
        {
            await _menuWriteRepository.RemoveAsync(request.Id);
            await _menuWriteRepository.SaveAsync();
            return new();
        }
    }
}
