using MyTraceLib.Services;
using MyTraceLib.Tables;

namespace MyTraceTrawler.Trawlers
{
    public static class ColesTrawler
    {
        public static async Task TrawlProductsAsync(int initialOffset = 0)
        {
            int offset = initialOffset;
            List<ColesProductResult> allResults = new List<ColesProductResult>();

            while (true)
            {
                var productPage = await FunctionsService.GetColesProductPageAsync(offset);
                if (productPage?.Results == null || productPage.Results.Length == 0)
                {
                    break;
                }

                allResults.AddRange(productPage.Results);
                offset += productPage.Limit;

                Console.WriteLine($"Fetched {allResults.Count} of {productPage.TotalResults} products.");
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

            await ColesSqlService.SaveProductsAsync(products);
            Console.WriteLine("Done saving products to the database.");
        }

        public static async Task TrawlBrandsAsync(int initialOffset = 0)
        {
            int offset = initialOffset;
            List<ColesBrandResult> allResults = new List<ColesBrandResult>();

            while (true)
            {
                var brandPage = await FunctionsService.GetColesBrandPageAsync(offset);
                if (brandPage?.Results == null || brandPage.Results.Length == 0)
                {
                    break;
                }

                allResults.AddRange(brandPage.Results);
                offset += brandPage.Limit;

                Console.WriteLine($"Fetched {allResults.Count} of {brandPage.TotalResults} brands.");
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

            await ColesSqlService.SaveBrandsAsync(brands);
            Console.WriteLine("Done saving brands to the database.");
        }
    }
}
