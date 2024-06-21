using MyTraceLib.Tables;
using MyTraceLib.Services;
using MyTraceTrawler.Trawlers;

namespace MyTraceTrawler
{
    public class Program
    {
        public static bool printMode = false;
        public static string _connectionString = "Server=tcp:mytrace.database.windows.net,1433;" +
                    "Initial Catalog=MyTrace;" +
                    "Persist Security Info=False;" +
                    "User ID=mytrace;" +
                    "Password=John8:32;" +
                    "MultipleActiveResultSets=False;" +
                    "Encrypt=True;" +   
                    "TrustServerCertificate=False;" +
                    "Connection Timeout=30;";
        private static string colesApiKey = "ca2Fg3art28TTfVRgCsm4iMaZF16WgaNkNOKO4yDc6uGc";
        static async Task Main(string[] args)
        {
            await TestWoolworthsMatchingProductsAsync("9352357004479");
        }

        static async Task ColesTrawlMode()
        {
            await ColesTrawler.TrawlProductsAsync();
            await ColesTrawler.TrawlBrandsAsync();
        }
        static async Task WoolworthsStockCodeIndexTrawlMode(int lowerBound = 0, int upperBound = 9999999)
        {
            PrintService.PrintInfo($"Starting MyTraceTrawler in Woolworths StockCode indexing mode for stock codes between {lowerBound} - {upperBound}");
            await WoolworthsTrawler.TrawlStockCodesBarcodesToIndexAsync(lowerBound, upperBound);
        }
        static async Task TestWoolworthsMatchingProductsAsync(string barcode)
        {
            PrintService.PrintInfo($"Starting search for {barcode}");
            var product = await WoolworthsSqlService.GetProductByBarcodeAsync(barcode);

            if (product == null)
            {
                PrintService.PrintFailure("No product found.");
            }
            else
            {
                PrintService.PrintSuccess($"Found product! {product.Name}");
                
                PrintService.PrintInfo($"Department: {product.SapDepartment}");
                PrintService.PrintInfo($"Category: {product.SapCategory}");
                PrintService.PrintInfo($"SubCategory: {product.SapSubCategory}");
                PrintService.PrintInfo($"Segment: {product.SapSegment}");
                PrintService.PrintInfo("Searching similar products.");
                List<WoolworthsProduct> products = await WoolworthsSqlService.GetMatchingProductsAsync(product);
                foreach (var p in products)
                {
                    PrintService.PrintInfo($"{p.Name} - {p.Barcode}");
                }
            }
           
        }
    }
}
