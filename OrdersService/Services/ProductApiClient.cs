using OrdersService.Models;

namespace OrdersService.Services
{
    public class ProductApiClient
    {
        private readonly HttpClient _client;

        public ProductApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var response = await _client.GetAsync($"api/products/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<Product>();
        }
    }
}
