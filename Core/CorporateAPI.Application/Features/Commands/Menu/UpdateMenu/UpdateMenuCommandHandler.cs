using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Menu.UpdateMenu
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommandRequest, UpdateMenuCommandResponse>
    {
        readonly IMenuWriteRepository _menuWriteRepository;
        readonly IMenuReadRepository _menuReadRepository;

        public UpdateMenuCommandHandler(IMenuWriteRepository menuWriteRepository, IMenuReadRepository menuReadRepository)
        {
            _menuWriteRepository = menuWriteRepository;
            _menuReadRepository = menuReadRepository;
        }

        public async Task<UpdateMenuCommandResponse> Handle(UpdateMenuCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Menu menu=await _menuReadRepository.GetByIdAsync(request.Id);
            menu.Name = request.Name;
            menu.Url = request.Url;
            menu.Order = request.Order;
            menu.ParentId = request.ParentId;
            menu.UpdatedDate=DateTime.Now;
            _menuWriteRepository.Update(menu);
            await _menuWriteRepository.SaveAsync();
            return new();
        }
    }
}
