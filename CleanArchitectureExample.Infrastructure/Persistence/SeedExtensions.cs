using CleanArchitectureExample.Domain.Primitives;
using CleanArchitectureExample.Domain.Products;
using CleanArchitectureExample.Infrastructure.Persistence.Context;

namespace CleanArchitectureExample.Infrastructure.Persistence
{
    /// <summary>
    /// Contains the extension method for seeding the database with initial data.
    /// </summary>
    public static class SeedExtensions
    {
        /// <summary>
        /// Seeds the database with initial data.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public static void SeedDatabase(this ApplicationDbContext dbContext)
        {
            dbContext.Set<Product>().AddRange(new List<Product>
            {
                new Product(
                    new ProductId(Guid.NewGuid()),
                    "T-Shirt",
                    new Money("USD", 15),
                    Sku.Create("XL123456")),
                new Product(
                    new ProductId(Guid.NewGuid()),
                    "Trousers",
                    new Money("USD", 115),
                    Sku.Create("XL123456"))
            });

            dbContext.SaveChanges();
        }
    }
}
