using Microsoft.AspNetCore.Mvc;
using MVC_CS.Models;
using MVC_CS.Services;

namespace MVC_CS.Controllers
{
    public class ProductController: Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }

        public IActionResult Create()
        {
            var categories = _productService.GetCategories();
            return View(categories);
        }
        
        public IActionResult Update(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();
            ViewBag.Product = product;
            var categories = _productService.GetCategories();
            return View(categories);
        }

        public IActionResult Save(Product value)
        {
            var product = _productService.GetProductById(value.Id);
            if (product == null)
                _productService.CreateProduct(value);
            else
                _productService.UpdateProduct(value);
            return RedirectToAction("Index");
        }
    }
}
