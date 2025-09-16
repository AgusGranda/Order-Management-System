namespace OrderService.Services
{

    public interface IProductServiceClient
    {
        Task<bool> CheckStockAsync(int productId, int quantity);
        Task<T> PutAsync<T>(string productId);

    }


    public class ProductServiceClient : IProductServiceClient
    {
        private readonly HttpClient _httpClient;

        public ProductServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CheckStockAsync(int productId, int quantity)
        {
            var response = await _httpClient.GetAsync($"products/{productId}/stock?quantity={quantity}");

            if (!response.IsSuccessStatusCode)
                return false;

            var content = await response.Content.ReadAsStringAsync();
            return bool.Parse(content); // ProductService devuelve true/false
        }

        public Task<T> PutAsync<T>(string productId)
        {
            throw new NotImplementedException("not implemented");
        }
    }
}
