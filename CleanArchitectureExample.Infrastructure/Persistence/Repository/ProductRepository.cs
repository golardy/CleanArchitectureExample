using CleanArchitectureExample.Application.Common.Interfaces;
using CleanArchitectureExample.Domain.Primitives;
using CleanArchitectureExample.Domain.Products;
using CleanArchitectureExample.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureExample.Infrastructure.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

        public void Add(Product product) => _applicationDbContext.Set<Product>().Add(product);

        public async Task<Product> GetByIdAsync(ProductId id)
        {
            return await _applicationDbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Product product)
        {
            _applicationDbContext.Set<Product>().Remove(product);
        }
    }
}
