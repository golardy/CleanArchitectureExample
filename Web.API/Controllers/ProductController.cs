using CleanArchitectureExample.Application.Contracts;
using CleanArchitectureExample.Application.Products.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.API.Constants;
using Web.API.Contracts;
using Web.API.Infrastructure;

namespace Web.API.Controllers
{
    public class ProductController : ApiController
    {
        public ProductController(ISender sender)
            : base(sender)
        {
        }

        [HttpPost(ApiRoutes.Product.Create)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IResult> Create([FromBody] CreateProductRequest createProductRequest, CancellationToken cancellationToken)
        {
            await Sender.Send(new CreateProductCommand(
                    createProductRequest.Name,
                    createProductRequest.Sku.Value,
                    createProductRequest.Money.Currency,
                    createProductRequest.Money.Amount), cancellationToken);

            return Results.Ok();
        }
    }
}