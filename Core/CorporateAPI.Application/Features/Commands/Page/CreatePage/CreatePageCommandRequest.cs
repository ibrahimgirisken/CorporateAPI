using CorporateAPI.Application.DTOs.Page;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Page.CreatePage
{
    public class CreatePageCommandRequest:IRequest<CreatePageCommandResponse>
    {
        public CreatePageDTO PageDto{ get; set; }
    }
}
