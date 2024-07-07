using MyTraceLib.Services;
using MyTraceLib.Tables;

namespace MyTraceTrawler.Trawlers
{
    public static class CostcoTrawler
    {
        public static async Task TrawlProductsAsync(int initialOffset = 0)
        {
            PrintService.PrintInfo("Trawling Costco Products");
            List<CostcoProduct> CostcoProducts = await CostcoApiService.GetAllCostcoProductsAsync(initialOffset);
            PrintService.PrintInfo($"Collected {CostcoProducts.Count} products. Saving to database...");
            //await CostcoSqlService.SaveProductsAsync(CostcoProducts);
            PrintService.PrintSuccess($"Done!");
        }

        public static async Task TrawlBrandsAsync()
        {
            PrintService.PrintInfo("Trawling Costco Brands");
            List<CostcoBrand> CostcoBrands = await CostcoApiService.GetAllCostcoBrandsAsync();
            PrintService.PrintInfo($"Collected {CostcoBrands.Count} brands. Saving to database...");
            //await CostcoSqlService.SaveBrandsAsync(CostcoBrands);
        }
    }
}
