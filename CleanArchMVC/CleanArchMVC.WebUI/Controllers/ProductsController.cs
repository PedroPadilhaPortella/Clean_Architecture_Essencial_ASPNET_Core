using CleanArchMVC.Application.DTO;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDTO> products = await _productService.GetAll();
            return View(products);
        }
    }
}
