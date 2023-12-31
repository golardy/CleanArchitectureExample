﻿using CleanArchitectureExample.Application.Core.Abstractions.Data;
using CleanArchitectureExample.Domain.Primitives;
using CleanArchitectureExample.Domain.Products;
using MediatR;

namespace CleanArchitectureExample.Application.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                new ProductId(Guid.NewGuid()),
                request.Name,
                new Money(request.Currency, request.Amount),
                Sku.Create(request.Sku)!);

            _productRepository.Add(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
