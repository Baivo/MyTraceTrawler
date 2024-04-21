using Newtonsoft.Json;
using System.Net;

namespace WooliesScraper
{
    internal class WoolworthsApiHandler
    {
        private readonly HttpClient client;

        public WoolworthsApiHandler()
        {
            var handler = new HttpClientHandler
            {
                CookieContainer = new CookieContainer(),
                UseCookies = true,
            };
            client = new HttpClient(handler);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:124.0) Gecko/20100101 Firefox/124.0");
        }

        public async Task InitializeSession()
        {
            // Initial request to capture cookies and set up the session
            var response = await client.GetAsync("https://www.woolworths.com.au");
            response.EnsureSuccessStatusCode();
        }

        public async Task<ProductDetail> GetProductDetails(int productId)
        {
            try
            {
                var apiUrl = $"https://www.woolworths.com.au/apis/ui/product/detail/{productId}?isMobile=false&useVariant=true";
                var apiResponse = await client.GetAsync(apiUrl);
                if (!apiResponse.IsSuccessStatusCode)
                    return null;

                string responseBody = await apiResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductDetail>(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching product {productId}: {ex.Message}");
                return null;
            }
        }
    }

    internal class ProductDetail
    {
        public Product Product { get; set; }
    }

    internal class Product
    {
        public int Stockcode { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var apiHandler = new WoolworthsApiHandler();
            await apiHandler.InitializeSession();  // Initialize session once

            int startProductId = 300000;
            int maxTasks = 1;  // Number of concurrent tasks

            while (true)
            {
                var tasks = new List<Task>();
                for (int i = 0; i < maxTasks; i++)
                {
                    int productId = startProductId + i;
                    tasks.Add(ProcessProduct(apiHandler, productId));
                }

                await Task.WhenAll(tasks);
                startProductId += maxTasks;
            }
        }

        static async Task ProcessProduct(WoolworthsApiHandler apiHandler, int productId)
        {
            var productDetail = await apiHandler.GetProductDetails(productId);
            if (productDetail?.Product != null)
            {
                Console.WriteLine($"Product {productId}: {productDetail.Product.Name}, Price: {productDetail.Product.Price}");
            }
            else
            {
                Console.WriteLine($"No product found for ID {productId}");
            }
        }
    }
}
