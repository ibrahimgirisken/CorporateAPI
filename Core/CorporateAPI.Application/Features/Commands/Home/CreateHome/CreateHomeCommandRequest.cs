using CorporateAPI.Application.DTOs.Home;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Home.CreateHome
{
    public class CreateHomeCommandRequest:IRequest<CreateHomeCommandResponse>
    {
        public CreateHomeCommandRequest()
        {
            HomeTranslations = new HashSet<HomeTranslationDTO>();
        }
        public int Id { get; set; }
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<HomeTranslationDTO> HomeTranslations { get; set; }
    }
}
