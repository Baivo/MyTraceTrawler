using MyTraceTrawler.Tables;
using Newtonsoft.Json;

namespace MyTraceTrawler.Services
{
    internal class ColesApiService
    {
        private static string _apiKey { get; set; } = "ca2Fg3art28TTfVRgCsm4iMaZF16WgaNkNOKO4yDc6uGc";
        private static int maxConcurrency = 100;
        private static async Task<ColesProductResponsePage?> GetProductPageAsync(int offset = 0)
        {
            using var client = new HttpClient();
            string requestUri = $"https://api.bazaarvoice.com/data/products.json?passkey={_apiKey}&locale=en_AU&allowMissing=true&apiVersion=5.4&limit=100&offset={offset}";
            var response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ColesProductResponsePage>(responseBody);
        }
        public static async Task<List<ColesProduct>> GetAllColesProductsAsync(int initialOffset = 0)
        {
            var initialResponse = await GetProductPageAsync(initialOffset);
            if (initialResponse == null || initialResponse.Results == null || initialResponse.Results.Length == 0)
                throw new InvalidOperationException("Failed to fetch initial data from API.");

            int totalResults = initialResponse.TotalResults;
            PrintService.PrintInfo($"Starting product data fetch: {totalResults} total items to retrieve.");

            List<ColesProductResult> allResults = new List<ColesProductResult>(initialResponse.Results);
            List<Task<ColesProductResponsePage?>> tasks = new List<Task<ColesProductResponsePage?>>();

            for (int offset = initialResponse.Limit; offset < totalResults; offset += initialResponse.Limit * maxConcurrency)
            {
                tasks.Clear();
                for (int i = 0; i < maxConcurrency && offset + i * initialResponse.Limit < totalResults; i++)
                {
                    int currentOffset = offset + i * initialResponse.Limit;
                    tasks.Add(GetProductPageAsync(currentOffset));
                }

                var responses = await Task.WhenAll(tasks);
                foreach (var response in responses)
                {
                    if (response?.Results != null)
                    {
                        allResults.AddRange(response.Results);
                        PrintService.PrintInfo($"Fetched {allResults.Count} of {totalResults} products");
                    }
                }
            }
            List<ColesProduct> products = new List<ColesProduct>();
            foreach (var productResult in allResults)
            {
                string brandName = productResult.Brand?.Name ?? "Coles";

                var entity = new ColesProduct
                {
                    ColesProductId = productResult.Id ?? Guid.NewGuid().ToString(),
                    Name = productResult.Name,
                    Active = productResult.Active,
                    StockCode = productResult.Id,
                    Brand = brandName,
                    BrandExternalId = productResult.BrandExternalId,
                    EANs = productResult.EANs,
                    ManufacturerPartNumbers = productResult.ManufacturerPartNumbers,
                    UPCs = productResult.UPCs,
                    ImageUrl = productResult.ImageUrl,
                    ProductPageUrl = productResult.ProductPageUrl
                };
                products.Add(entity);
            }
            return products;
        }
        private static async Task<ColesBrandResponsePage?> GetBrandPageAsync(int offset = 0)
        {
            using var client = new HttpClient();
            string requestUri = $"https://api.bazaarvoice.com/data/brands.json?passkey={_apiKey}&locale=en_AU&allowMissing=true&apiVersion=5.4&limit=100&offset={offset}";
            var response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ColesBrandResponsePage>(responseBody);
        }

        public static async Task<List<ColesBrand>> GetAllColesBrandsAsync()
        {
            int initialOffset = 0;
            var initialResponse = await GetBrandPageAsync(initialOffset);
            if (initialResponse == null || initialResponse.Results == null || initialResponse.Results.Length == 0)
                throw new InvalidOperationException("Failed to fetch initial data from API.");

            int totalResults = initialResponse.TotalResults;
            PrintService.PrintInfo($"Starting brand data fetch: {totalResults} total items to retrieve.");

            List<ColesBrandResult> allResults = new List<ColesBrandResult>(initialResponse.Results);
            List<Task<ColesBrandResponsePage?>> tasks = new List<Task<ColesBrandResponsePage?>>();

            for (int offset = initialResponse.Limit; offset < totalResults; offset += initialResponse.Limit * maxConcurrency)
            {
                tasks.Clear();
                for (int i = 0; i < maxConcurrency && offset + i * initialResponse.Limit < totalResults; i++)
                {
                    int currentOffset = offset + i * initialResponse.Limit;
                    tasks.Add(GetBrandPageAsync(currentOffset));
                }

                var responses = await Task.WhenAll(tasks);
                foreach (var response in responses)
                {
                    if (response?.Results != null)
                    {
                        allResults.AddRange(response.Results);
                        PrintService.PrintInfo($"Fetched {allResults.Count} of {totalResults} brands");
                    }
                }
            }
            List<ColesBrand> brands = new List<ColesBrand>();
            foreach (var brandResult in allResults)
            {
                var entity = new ColesBrand
                {
                    ColesBrandId = brandResult.Id ?? Guid.NewGuid().ToString(),
                    Name = brandResult.Name,
                    InternalId = brandResult.Id ?? "NoID"
                };
                brands.Add(entity);
            }
            return brands;
        }
    }
}