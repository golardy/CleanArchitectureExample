using CleanArchitectureExample.Domain.Primitives;

namespace CleanArchitectureExample.Domain.Products
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(ProductId productId)
            :base($"The product with ID = {productId.Value} was not found")
        { 
        }
    }
}
