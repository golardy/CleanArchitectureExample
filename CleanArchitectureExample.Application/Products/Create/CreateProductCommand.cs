using MediatR;

namespace CleanArchitectureExample.Application.Products.Create
{
    public record CreateProductCommand(
        string Name, 
        string Sku,
        string Currency,
        decimal Amount) : IRequest;
}
