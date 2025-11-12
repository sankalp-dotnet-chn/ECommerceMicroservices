using Microsoft.AspNetCore.Mvc;
using ProductsService.Models;

namespace ProductsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 70000 },
            new Product { Id = 2, Name = "Mouse", Price = 1000 },
            new Product { Id = 3, Name = "Keyboard", Price = 2500 }
        };

        [HttpGet]
        public IActionResult GetAllProducts() => Ok(Products);

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}
