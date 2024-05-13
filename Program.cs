using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using WooliesScraper.Products;
using WooliesScraper.WooliesScraper.Products.WooliesScraper.Products;

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

        public async Task<WooliesProduct> RequestProductAsync(int productId)
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
    }


    internal class Program
    {
        static async Task Main(string[] args)
        {
            Random random = new Random();
            var apiHandler = new WoolworthsApiHandler();
            await apiHandler.InitializeSession(); 

            while (true)
            {
                int pID = random.Next(999999);
                await ProcessProduct(apiHandler, pID);
            }


            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter product ID to search or 'exit' to quit:");
                var product = Console.ReadLine();
                if (product != null)
                {
                    if (product == "exit")
                        break;

                    int productID;
                    bool isValid = int.TryParse(product, out productID);
                    if (isValid)
                    {
                        await ProcessProduct(apiHandler, productID);
                    }
                }
            }
        }

        public static async Task ProcessProduct(WoolworthsApiHandler apiHandler, int productId)
        {
            TableStorageService tableStorageService = new();
            PrintStatusHeader($"Beginning lookup for product ID {productId}");
            bool isSaved = await ProductSavedAsync(productId);
            if (isSaved) 
            {
                PrintStatusHeader("Product already saved.");
                //bool isValid = await ProductValidAsync(productId);
                //if (!isValid)
                //{
                //    Console.WriteLine($"Product invalid for product ID {productId}");
                //    return;
                //}
                //else
                //{
                //    var existingProductEntity = await tableStorageServicfe.GetMostRecentEntityAsync<ProductTableEntity>("woolies-products", productId.ToString());
                //    var existingProduct = existingProductEntity.GetProduct();
                //    EnhancedPrintProduct(existingProduct);
                //}
                return;
            }
            PrintStatusHeader("No saved record of product. Attempting product query...");

            WooliesProduct? product = await apiHandler.RequestProductAsync(productId);

            if (product?.Product != null)
            {
                EnhancedPrintProduct(product);
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
                Console.WriteLine($"No product found for ID {productId}");
            }
        }
        public static async Task<bool> ProductSavedAsync(int productId)
        {
            TableStorageService tableStorageService = new();
            return await tableStorageService.EntityExistsAsync<ProductTableEntity>("woolies-product-check", "product-valid", productId.ToString());
        }
        public static async Task<bool> ProductValidAsync(int productId)
        {
            TableStorageService tableStorageService = new();
            var entity = await tableStorageService.GetEntityAsync<ProductValidTableEntity>("woolies-product-check", "product-valid", productId.ToString());
            return entity.IsValid;
        }


        public static void PrintInfoHeader(string header)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("[i] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(header);
            Console.ResetColor();
        }
        public static void PrintStatusHeader(string header)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("[i] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(header);
            Console.ResetColor();
        }

        public static void PrintPropertyName(string name)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  " + name + ": ");
            Console.ResetColor();
        }

        public static void PrintPropertyValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void PrintNullValue()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("null");
            Console.ResetColor();
        }
        public static void EnhancedPrintProduct(WooliesProduct product)
        {
            if (product == null)
            {
                PrintInfoHeader("Product not found.");
                return;
            }

            PrintInfoHeader("Product Information");
            PrintProperties(product.Product, 1);

            PrintInfoHeader("Additional Attributes");
            PrintProperties(product.AdditionalAttributes, 1);

            PrintInfoHeader("Country of Origin");
            PrintProperties(product.CountryOfOriginLabel, 1);

            PrintInfoHeader("Nutritional Information");
            if (product.NutritionalInformation != null)
            {
                foreach (var info in product.NutritionalInformation)
                {
                    PrintProperties(info, 1);
                }
            }
            else
            {
                PrintNullValue();
            }

            Console.ResetColor();
        }

        private static void PrintProperties(object obj, int indentLevel)
        {
            if (obj == null)
            {
                PrintNullValue();
                return;
            }

            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                PrintPropertyName(new string(' ', indentLevel * 2) + property.Name);

                if (value == null)
                {
                    PrintNullValue();
                }
                else if (value.GetType().IsClass && !value.GetType().IsAssignableFrom(typeof(string)) && !(value is System.Collections.IEnumerable))
                {
                    Console.WriteLine();
                    PrintProperties(value, indentLevel + 1);
                }
                else if (value is System.Collections.IEnumerable && !(value is string))
                {
                    Console.WriteLine();
                    foreach (var item in (System.Collections.IEnumerable)value)
                    {
                        if (item == null)
                        {
                            PrintNullValue();
                        }
                        else
                        {
                            PrintPropertyValue(new string(' ', (indentLevel + 1) * 4) + item.ToString());
                        }
                    }
                }
                else
                {
                    PrintPropertyValue(value.ToString());
                }
            }
        }

    }
}
