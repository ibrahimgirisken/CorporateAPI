using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly CorporateAPIDbContext _context;

        public ReadRepository(CorporateAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        => Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
       =>Table.Where(method);
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
       =>await Table.FirstOrDefaultAsync(method);
        public async Task<T> GetByIdAsync(string id)
        => await Table.FirstOrDefaultAsync(e=>e.Id==Guid.Parse(id));


    }
}
