using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CleanArchitectureExample.Application.Core.Abstractions.Data;

namespace CleanArchitectureExample.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var cs = base.Database.GetDbConnection().ConnectionString;

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
