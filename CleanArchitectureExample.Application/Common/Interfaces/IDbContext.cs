namespace CleanArchitectureExample.Application.Common.Interfaces
{
    public interface IDbContext
    {
        Task<TEntity?> GetByIdAsync<TEntity>(Guid id);

        void Add<TEntity>(TEntity entity);

        void Update<TEntity>(TEntity entity);
    }
}
