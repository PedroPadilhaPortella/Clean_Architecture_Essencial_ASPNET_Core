using CleanArchMVC.Application.DTO;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDTO> products = await _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(await _categoryService.GetAll(), "Id", "Name");
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var productDTO = await _productService.GetById(id);

            if (productDTO == null) return NotFound();

            IEnumerable<CategoryDTO> categories = await _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", productDTO.CategoryId);

            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(productDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(productDTO);
        }
    }
}
