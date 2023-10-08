using CleanArchitectureExample.Domain.Primitives;

namespace CleanArchitectureExample.Domain.Products
{
    public class Product
    {
        public ProductId Id { get; private set; }

        public string Name { get; private set; } = string.Empty;
        public Money Price { get; private set; }

        public Sku Sku { get; private set; }

        public Product(ProductId id, string name, Money price, Sku sku)
        {
            Id = id;
            Name = name;
            Price = price;
            Sku = sku;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <remarks>
        /// Required by EF Core.
        /// </remarks>
        private Product()
        {
        }
    }
}
