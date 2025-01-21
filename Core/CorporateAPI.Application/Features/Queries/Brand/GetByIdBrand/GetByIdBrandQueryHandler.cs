using AutoMapper;
using CorporateAPI.Application.DTOs.Brand;
using CorporateAPI.Application.Repositories.Brand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Brand.GetByIdBrand
{
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQueryRequest, GetByIdBrandQueryResponse>
    {
        readonly IBrandReadRepository _brandReadRepository;
        readonly IMapper _mapper;

        public GetByIdBrandQueryHandler(IBrandReadRepository brandReadRepository, IMapper mapper)
        {
            _brandReadRepository = brandReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdBrandQueryResponse> Handle(GetByIdBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var brand= await _brandReadRepository.GetByIdAsync(request.Id);
            var brandDto=_mapper.Map<ResultBrandDTO>(brand);
            return new()
            {
                Brand = brandDto
            };
        }
    }
}
