using CleanArchitectureExample.Domain.Primitives;

namespace CleanArchitectureExample.Application.Contracts
{
    public sealed class DeleteProductRequest
    {
        public ProductId ProductId { get; set; }
    }
}
