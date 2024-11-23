using CorporateAPI.Domain.Entities.Relationship;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.CreatePage
{
    public class CreatePageCommandRequest:IRequest<CreatePageCommandResponse>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public ICollection<Guid?> ModuleIds { get; set; }
    }
}
