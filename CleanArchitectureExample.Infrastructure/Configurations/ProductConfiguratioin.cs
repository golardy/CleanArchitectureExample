using CleanArchitectureExample.Domain.Primitives;
using CleanArchitectureExample.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureExample.Infrastructure.Configurations
{
    public class ProductConfiguratioin : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(
                productId => productId.Value,
                value => new ProductId(value));

            builder.Property(x => x.Sku).HasConversion(
                sku => sku.Value,
                value => Sku.Create(value));

            builder.OwnsOne(p => p.Price, ppriceBuilder => 
            {
                ppriceBuilder.Property(m => m.Currency).HasMaxLength(3);
            });
        }
    }
}
