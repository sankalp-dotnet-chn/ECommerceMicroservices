using Microsoft.AspNetCore.Mvc;
using OrdersService.Models;
using OrdersService.Services;

namespace OrdersService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> Orders = new();
        private readonly ProductApiClient _productApiClient;

        public OrdersController(ProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        [HttpGet]
        public IActionResult GetAllOrders() => Ok(Orders);

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order newOrder)
        {
            var product = await _productApiClient.GetProductByIdAsync(newOrder.ProductId);
            if (product == null)
                return BadRequest($"Product with ID {newOrder.ProductId} not found.");

            newOrder.TotalPrice = newOrder.Quantity * product.Price;
            newOrder.Id = Orders.Count + 1;
            Orders.Add(newOrder);

            return CreatedAtAction(nameof(GetAllOrders), new { id = newOrder.Id }, newOrder);
        }
    }
}
