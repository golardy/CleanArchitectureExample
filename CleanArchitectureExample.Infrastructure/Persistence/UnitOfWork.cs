using CleanArchitectureExample.Application.Common.Interfaces;
using CleanArchitectureExample.Infrastructure.Persistence.Context;

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
            return await _applicationDBContext.SaveChangesAsync(cancellationToken);
        }
    }
}
