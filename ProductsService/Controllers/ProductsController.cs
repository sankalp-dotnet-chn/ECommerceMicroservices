using Microsoft.AspNetCore.Mvc;

namespace ProductsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new[] { "Laptop", "Mouse", "Keyboard" });
        }
    }
}
