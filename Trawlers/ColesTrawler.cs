using MyTraceLib.Services;
using MyTraceLib.Tables;

namespace MyTraceTrawler.Trawlers
{
    public static class ColesTrawler
    {
        public static async Task TrawlProductsAsync(int initialOffset = 0)
        {
            PrintService.PrintInfo("Trawling Coles Products");
            List<ColesProduct> colesProducts = await ColesApiService.GetAllColesProductsAsync(initialOffset);
            PrintService.PrintInfo($"Collected {colesProducts.Count} products. Saving to database...");
            await ColesSqlService.SaveProductsAsync(colesProducts);
            PrintService.PrintSuccess($"Done!");
        }

        public static async Task TrawlBrandsAsync()
        {
            PrintService.PrintInfo("Trawling Coles Brands");
            List<ColesBrand> colesBrands = await ColesApiService.GetAllColesBrandsAsync();
            PrintService.PrintInfo($"Collected {colesBrands.Count} brands. Saving to database...");
            await ColesSqlService.SaveBrandsAsync(colesBrands);
        }
    }
}
