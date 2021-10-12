using AutoMapper;
using CleanArchMVC.Application.DTO;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMediator mediator, IProductRepository productRepository, IMapper mapper)
        {
            _mediator = mediator;
            _productRepository = productRepository ?? 
                throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            //IEnumerable<Product> productsEntity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
            var productsQueries = new GetProductsQueries();

            if (productsQueries == null) 
                throw new ApplicationHandlerException($"Entity could not be load");

            var result = await _mediator.Send(productsQueries);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            //Product productEntity = await _productRepository.GetByIdAsync(id);
            //return _mapper.Map<ProductDTO>(productEntity);

            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity could not be found");

            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    Product productEntity = await _productRepository.GetProductCategoryAsync(id);
        //    return _mapper.Map<ProductDTO>(productEntity);
        //}

        public async Task Add(ProductDTO productDTO)
        {
            //Product productEntity = _mapper.Map<Product>(productDTO);
            //await _productRepository.CreateAsync(productEntity);

            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            //Product productEntity = _mapper.Map<Product>(productDTO);
            //await _productRepository.UpdateAsync(productEntity);

            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            //Product productEntity = await _productRepository.GetByIdAsync(id);
            //await _productRepository.RemoveAsync(productEntity);

            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if(productRemoveCommand == null)
                throw new Exception($"Entity could not be found");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
