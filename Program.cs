using MyTraceTrawler.Tables;
using MyTraceTrawler.Services;
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
        static async Task TestWoolworthsMatchingProductsAsync()
        {
            string sapDepartment = "GROCERIES";
            string sapCategory = "ETHNIC / GOURMET FOOD";
            string sapSubCategory = "AUTHENTIC INDIAN";
            string sapSegment = "SEASONINGS / SPICES";


            List<WoolworthsProduct> products = await WoolworthsSqlService.GetMatchingProductsAsync(sapDepartment, sapCategory, sapSubCategory, sapSegment);
            foreach (var product in products)
            {
                PrintService.PrintInfo($"{product.Name} - {product.Barcode}");
            }
        }
    }
}
