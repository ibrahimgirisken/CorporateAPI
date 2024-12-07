using CorporateAPI.Application.DTOs.PageDto;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Page.GetAllPage
{
    public class GetAllPageQueryHandler : IRequestHandler<GetAllPageQueryRequest, GetAllPageQueryResponse>
    {
        readonly IPageReadRepository _pageReadRepository;

        public GetAllPageQueryHandler(IPageReadRepository pageReadRepository)
        {
            _pageReadRepository = pageReadRepository;
        }

        public async Task<GetAllPageQueryResponse> Handle(GetAllPageQueryRequest request, CancellationToken cancellationToken)
        {
            var pages = _pageReadRepository.GetAll(false).ToList();
            var pageDtos = pages.Select(page => new PageDto
            {
                Content = page.Content,
                Order = page.Order,
                ParentId = page.ParentId,
                Slug = page.Slug,
                Status = page.Status,
                Title = page.Title,
                Type = page.Type,
                SubPages =GetSubPages(page.Id,pages)
            }).ToList();

            return new()
            {
                Pages=pageDtos,
            };

        }

        private List<PageDto> GetSubPages(int parentId,List<Domain.Entities.Page> pages) {
            return pages.Where(p => p.ParentId == parentId)
                .Select(p => new PageDto
                {
                    Title = p.Title,
                    Content = p.Content,
                    ParentId = parentId,
                    Order = p.Order,
                    Slug = p.Slug,
                    Status = p.Status,
                    Type = p.Type,
                    SubPages = GetSubPages(p.Id, pages)
                }).ToList();
        }
    }
}
