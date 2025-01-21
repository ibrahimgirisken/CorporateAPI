using AutoMapper;
using CorporateAPI.Application.DTOs.Brand;
using CorporateAPI.Application.Repositories.Brand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Brand.GetAllBrand
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQueryRequest, GetAllBrandQueryResponse>
    {
        readonly IBrandReadRepository _brandReadRepository;
        readonly IMapper _mapper;

        public GetAllBrandQueryHandler(IBrandReadRepository brandReadRepository, IMapper mapper)
        {
            _brandReadRepository = brandReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllBrandQueryResponse> Handle(GetAllBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = _brandReadRepository.GetAll().ToList();
            var brandsDto=_mapper.Map<List<ResultBrandDTO>>(brands);
            return new()
            {
                Brands = brandsDto
            };

        }
    }
}
