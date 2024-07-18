using MyTraceLib.Services;
using MyTraceLib.Tables;

namespace MyTraceTrawler.Trawlers
{
    public static class CostcoTrawler
    {
        public static async Task TrawlProductsAsync(int initialOffset = 0)
        {
            int offset = initialOffset;
            List<CostcoProductResult> allResults = new List<CostcoProductResult>();

            while (true)
            {
                var productPage = await FunctionsService.GetCostcoProductPageAsync(offset);
                if (productPage?.Results == null || productPage.Results.Count == 0)
                {
                    break;
                }

                allResults.AddRange(productPage.Results);
                offset += productPage.Limit;

                Console.WriteLine($"Fetched {allResults.Count} of {productPage.TotalResults} products.");
            }

            List<CostcoProduct> products = new List<CostcoProduct>();
            foreach (var productResult in allResults)
            {
                string brandName = productResult.Brand?.Name ?? "Costco";

                var entity = new CostcoProduct
                {
                    CostcoProductId = productResult.Id ?? Guid.NewGuid().ToString(),
                    Name = productResult.Name,
                    Active = productResult.Active,
                    StockCode = productResult.Id,
                    Brand = brandName,
                    BrandExternalId = productResult.BrandExternalId,
                    ImageUrl = productResult.ImageUrl,
                    ProductPageUrl = productResult.ProductPageUrl
                };
                products.Add(entity);
            }

            await CostcoSqlService.SaveProductsAsync(products);
            Console.WriteLine("Done saving products to the database.");
        }

        public static async Task TrawlBrandsAsync(int initialOffset = 0)
        {
            int offset = initialOffset;
            List<CostcoBrandResult> allResults = new List<CostcoBrandResult>();

            while (true)
            {
                var brandPage = await FunctionsService.GetCostcoBrandPageAsync(offset);
                if (brandPage?.Results == null || brandPage.Results.Length == 0)
                {
                    break;
                }

                allResults.AddRange(brandPage.Results);
                offset += brandPage.Limit;

                Console.WriteLine($"Fetched {allResults.Count} of {brandPage.TotalResults} brands.");
            }

            List<CostcoBrand> brands = new List<CostcoBrand>();
            foreach (var brandResult in allResults)
            {
                var entity = new CostcoBrand
                {
                    CostcoBrandId = brandResult.Id ?? Guid.NewGuid().ToString(),
                    Name = brandResult.Name,
                    InternalId = brandResult.Id ?? "NoID"
                };
                brands.Add(entity);
            }

            await CostcoSqlService.SaveBrandsAsync(brands);
            Console.WriteLine("Done saving brands to the database.");
        }
    }
}
