using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Menu.UpdateMenu
{
    public class UpdateMenuCommandRequest:IRequest<UpdateMenuCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url{ get; set; }
        public int Order { get; set; }
        public Guid PageId { get; set; }
    }
}
