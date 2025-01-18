using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly private CorporateAPIDbContext _context;

        public WriteRepository(CorporateAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
          EntityEntry<T> entityEntry= await Table.AddAsync(model);
            return entityEntry.State==EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
          await Table.AddRangeAsync(datas);
         return true;
        }

        public bool Remove(T model)
        {
          EntityEntry<T> entityEntry= Table.Remove(model);
          return entityEntry.State==EntityState.Deleted;
        }
        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<bool> RemoveAsync(int id)
        {
          T data= await Table.FirstOrDefaultAsync(p => p.Id ==id);
           return Remove(data);
        }

        public bool Update(T model)
        {
          EntityEntry entityEntry=Table.Update(model);
            return entityEntry.State==EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return result;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

    }
}
