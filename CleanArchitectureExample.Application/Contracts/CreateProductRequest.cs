using CleanArchitectureExample.Domain.Primitives;

namespace CleanArchitectureExample.Application.Contracts
{
    public sealed class CreateProductRequest
    {
        public string Name { get; set; }
        public Money Money { get; set; }
        public Sku Sku { get; set; }
    }
}
