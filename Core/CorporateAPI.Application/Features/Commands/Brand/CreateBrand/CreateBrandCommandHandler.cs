using AutoMapper;
using CorporateAPI.Application.Repositories.Brand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Brand.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        readonly IBrandWriteRepository _brandWriteRepository;
        readonly IMapper _mapper;
        public CreateBrandCommandHandler(IBrandWriteRepository brandWriteRepository, IMapper mapper)
        {
            _brandWriteRepository = brandWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Domain.Entities.Brand.Brand>(request);
            await _brandWriteRepository.AddAsync(brand);
            await _brandWriteRepository.SaveAsync();
            return new();
        }
    }
}
