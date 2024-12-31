using AutoMapper;
using CorporateAPI.Application.DTOs.Lang;
using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.UpdateLang
{
    public class UpdateLangHandler : IRequestHandler<UpdateLangRequest, UpdateLangResponse>
    {
        readonly ILangWriteRepository _langWriteRepository;
        readonly ILangReadRepository _langReadRepository;
        readonly IMapper _mapper;

        public UpdateLangHandler(ILangWriteRepository langWriteRepository, IMapper mapper, ILangReadRepository langReadRepository)
        {
            _langWriteRepository = langWriteRepository;
            _mapper = mapper;
            _langReadRepository = langReadRepository;
        }

        public async Task<UpdateLangResponse> Handle(UpdateLangRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Lang lang = await _langReadRepository.GetByIdAsync(request.updateLangDTO.Id);
            _mapper.Map(request.updateLangDTO,lang);

            _langWriteRepository.Update(lang);
            await _langWriteRepository.SaveAsync();
            return new();
        }
    }
}
