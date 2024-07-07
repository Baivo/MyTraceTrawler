using System.CommandLine;
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
                    "Connection Timeout=300;";
        private static string colesApiKey = "ca2Fg3art28TTfVRgCsm4iMaZF16WgaNkNOKO4yDc6uGc";
        static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                Description = "Vendor specific operations"
            };

            var vendorOption = new Option<string>(
                new string[] { "-vendor", "--vendor" },
                description: "Specify the vendor (Coles, Woolworths, Costco)",
                getDefaultValue: () => string.Empty);

            rootCommand.AddOption(vendorOption);

            rootCommand.SetHandler(async (string vendor) => 
            {
                if (string.IsNullOrEmpty(vendor))
                    RunDefaultLogic();
                else
                {
                    switch (vendor.ToLower())
                    {
                        case "coles":
                            await RunColesLogicAsync();
                            break;
                        case "costco":
                            await RunCostcoLogicAsync();
                            break;
                        case "woolworths":
                            await RunWoolworthsLogicAsync();
                            break;
                        default:
                            Console.WriteLine($"Unknown vendor: {vendor}");
                            break;
                    }
                }
            }, vendorOption);

            return await rootCommand.InvokeAsync(args);
        }
        static void RunDefaultLogic()
        {
            PrintService.PrintInfo("Please provide a vendor to trawl e.g. -vendor Coles");

        }

        static async Task RunColesLogicAsync()
        {
            await ColesTrawler.TrawlProductsAsync();
            await ColesTrawler.TrawlBrandsAsync();
        }
        static async Task RunCostcoLogicAsync()
        {
            await CostcoTrawler.TrawlProductsAsync();
        }

        static async Task RunWoolworthsLogicAsync()
        {
            int batchCounter = 0;
            while (true)
            {
                await WoolworthsTrawler.TrawlWoolworthsProductsAsync(0, 9999999, batchCounter);
                batchCounter = batchCounter + 10;
            }
        }
    }
}
