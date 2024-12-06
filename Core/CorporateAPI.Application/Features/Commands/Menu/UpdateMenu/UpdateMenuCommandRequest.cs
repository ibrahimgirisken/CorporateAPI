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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url{ get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
    }
}
