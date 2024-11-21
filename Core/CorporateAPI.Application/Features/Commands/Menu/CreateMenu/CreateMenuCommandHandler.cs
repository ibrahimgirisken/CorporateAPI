using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Menu.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommandRequest, CreateMenuCommandResponse>
    {
        readonly IMenuWriteRepository _menuWriteRepository;

        public CreateMenuCommandHandler(IMenuWriteRepository menuWriteRepository)
        {
            _menuWriteRepository = menuWriteRepository;
        }

        public async Task<CreateMenuCommandResponse> Handle(CreateMenuCommandRequest request, CancellationToken cancellationToken)
        {
            await _menuWriteRepository.AddAsync(new()
            {
                Order = request.Order,
                Title = request.Title,
                Url = request.Url
                
            });
            await _menuWriteRepository.SaveAsync();
            return new();
        }
    }
}
