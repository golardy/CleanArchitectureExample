using CleanArchitectureExample.Domain.Primitives;
using CleanArchitectureExample.Domain.Products;

namespace CleanArchitectureExample.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(ProductId id);
        void Add(Product product);
        void Remove(Product product);
    }
}
