using AutoMapper;
using CorporateAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Lang.CreateLang
{
    public class CreateLangHandler : IRequestHandler<CreateLangRequest, CreateLangResponse>
    {
        readonly ILangWriteRepository _langWriteRepository;
        readonly IMapper _mapper;

        public CreateLangHandler(ILangWriteRepository langWriteRepository, IMapper mapper)
        {
            _langWriteRepository = langWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateLangResponse> Handle(CreateLangRequest request, CancellationToken cancellationToken)
        {
            var langs=_mapper.Map<Domain.Entities.Lang>(request.createLangDTO);
            await _langWriteRepository.AddAsync(langs);
            await _langWriteRepository.SaveAsync();
            return new();
        }
    }
}
