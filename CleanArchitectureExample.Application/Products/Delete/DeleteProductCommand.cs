using CleanArchitectureExample.Domain.Primitives;
using MediatR;

namespace CleanArchitectureExample.Application.Products.Delete
{
    public record DeleteProductCommand(ProductId ProductId) : IRequest;
}
