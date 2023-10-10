using CleanArchitectureExample.Application.Core.Abstractions.Data;
using CleanArchitectureExample.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureExample.Infrastructure.Persistence
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDBContext;
        public UnitOfWork(ApplicationDbContext applicationDBContext) 
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var cs = _applicationDBContext.Database.GetDbConnection().ConnectionString;

            return await _applicationDBContext.SaveChangesAsync(cancellationToken);
        }
    }
}
