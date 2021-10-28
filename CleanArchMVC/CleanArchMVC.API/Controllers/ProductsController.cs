using CleanArchMVC.Application.DTO;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;
        public ProductsController(IProductService productService)
        {
            _productsService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productsService.GetAll();

            if (products == null)
                return NotFound("Products not found");

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var product = await _productsService.GetById(id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest("Invalid Data");

            await _productsService.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Post(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return BadRequest("Invalid Id");

            if (productDTO == null)
                return BadRequest("Invalid Data");

            await _productsService.Update(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productsService.GetById(id);

            if (product == null)
                return NotFound("Product not Found");

            await _productsService.Remove(id);

            return Ok(product);
        }
    }
}
