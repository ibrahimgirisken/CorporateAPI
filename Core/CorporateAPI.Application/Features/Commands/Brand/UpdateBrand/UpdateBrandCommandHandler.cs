using AutoMapper;
using CorporateAPI.Application.Repositories.Brand;
using MediatR;


namespace CorporateAPI.Application.Features.Commands.Brand.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        readonly IBrandReadRepository _brandReadRepository;
        readonly IBrandWriteRepository _brandWriteRepository;
        readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandReadRepository brandReadRepository, IBrandWriteRepository brandWriteRepository, IMapper mapper)
        {
            _brandReadRepository = brandReadRepository;
            _brandWriteRepository = brandWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand=_mapper.Map<Domain.Entities.Brand.Brand>(request);
            _brandWriteRepository.Update(brand);
            await _brandWriteRepository.SaveAsync();
            return new();
        }
    }
}
