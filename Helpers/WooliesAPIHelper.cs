using System.Net;
using Azure.Data.Tables;
using Newtonsoft.Json;
using WooliesScraper.Entities;
using WooliesScraper.Products;
using static WooliesScraper.Helpers.PrintHelper;

namespace WooliesScraper.Helpers
{
    internal class WooliesAPIHelper
    {
        private readonly HttpClient client;
        private bool DebugMode { get; set; } = false;
        public WooliesAPIHelper(bool printMode = false)
        {
            DebugMode = printMode;
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
            var response = await client.GetAsync("https://www.woolworths.com.au");
            response.EnsureSuccessStatusCode();
        }

        private async Task<WooliesProduct> RequestProductAsync(int productId)
        {
            try
            {
                var apiUrl = $"https://www.woolworths.com.au/apis/ui/product/detail/{productId}?isMobile=false&useVariant=true";
                var apiResponse = await client.GetAsync(apiUrl);
                if (!apiResponse.IsSuccessStatusCode)
                    return null;

                string responseBody = await apiResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WooliesProduct>(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching product {productId}: {ex.Message}");
                return null;
            }
        }
        public async Task ProcessProduct(int productId)
        {
            TableStorageHelper tableStorageService = new();
            PrintInfoHeader($"Processing product ID: {productId}");
            bool isSaved = await ProductSavedAsync(productId);
            if (isSaved)
            {
                if (DebugMode)
                    PrintInfoHeader("Product already saved, checking existing record...");
                bool isValid = await ProductValidAsync(productId);
                if (!isValid)
                {
                    PrintFailure($"Product invalid for product ID: {productId}");
                    return;
                }
                else
                {
                    var existingProductEntity = await tableStorageService.GetMostRecentEntityAsync<ProductTableEntity>("woolies-products", productId.ToString());
                    WooliesProduct existingProduct = existingProductEntity.GetProduct();
                    IndexProduct(existingProduct);
                    string barcode = existingProduct.Product?.Barcode ?? string.Empty;
                    PrintSuccess($"Processed {productId} with barcode {barcode}");
                    if (DebugMode)
                        EnhancedPrintProduct(existingProduct);
                }
                
                return;
            }
            if (DebugMode)
                PrintInfoHeader("No saved record of product. Attempting product query...");

            WooliesProduct? product = await RequestProductAsync(productId);

            if (product?.Product != null)
            {
                if (DebugMode)
                    EnhancedPrintProduct(product);
                IndexProduct(product);
                var productEntity = new ProductTableEntity();
                productEntity.SetProduct(product, DateTime.UtcNow);
                await tableStorageService.AddEntityAsync("woolies-products", productEntity);

                ProductValidTableEntity productExistsTableEntity = new ProductValidTableEntity
                {
                    PartitionKey = "product-valid",
                    RowKey = productId.ToString(),
                    IsValid = true
                };
                await tableStorageService.AddEntityAsync("woolies-product-check", productExistsTableEntity);
            }
            else
            {
                ProductValidTableEntity productNotExistsTableEntity = new ProductValidTableEntity
                {
                    PartitionKey = "product-valid",
                    RowKey = productId.ToString(),
                    IsValid = false
                };
                await tableStorageService.AddEntityAsync("woolies-product-check", productNotExistsTableEntity);
                PrintFailure($"No product found for ID: {productId}");
            }
            PrintSuccess();
        }
        private async Task<bool> ProductSavedAsync(int productId)
        {
            TableStorageHelper tableStorageService = new();
            return await tableStorageService.EntityExistsAsync<ProductTableEntity>("woolies-product-check", "product-valid", productId.ToString());
        }
        private static async Task<bool> ProductValidAsync(int productId)
        {
            TableStorageHelper tableStorageService = new();
            var entity = await tableStorageService.GetEntityAsync<ProductValidTableEntity>("woolies-product-check", "product-valid", productId.ToString());
            return entity.IsValid;
        }
        private async void IndexProduct(WooliesProduct product)
        {
            try
            {
                TableStorageHelper tableStorageService = new TableStorageHelper();
                StockBarIndexTableEntity tableEntity = new StockBarIndexTableEntity(product);
                if (DebugMode)
                    PrintInfoHeader($"Indexing Barcode ({tableEntity.BarCode}) against Stock code ({tableEntity.StockCode})...");

                TableClient tableClient = tableStorageService.GetTableClient("stockcode-barcode-index");
                await tableClient.CreateIfNotExistsAsync();
                await tableClient.UpsertEntityAsync(tableEntity);
                if (DebugMode)
                    PrintSuccess();
            }
            catch
            {
                PrintFailure("Issue with missing product/barcode info, skipping...");
                return;
            }
        }

    }
}
