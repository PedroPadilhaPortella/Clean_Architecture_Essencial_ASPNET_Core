using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class GetProductsQueriesHandler : IRequestHandler<GetProductsQueries, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueriesHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQueries request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}