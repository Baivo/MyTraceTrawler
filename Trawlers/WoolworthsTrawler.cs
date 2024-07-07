using Microsoft.EntityFrameworkCore;
using MyTraceLib.Services;
using MyTraceLib.Tables;

namespace MyTraceTrawler.Trawlers
{
    public static class WoolworthsTrawler
    {
        public static async Task TrawlWoolworthsProductsAsync(int lowerStockCodeLimit = 0, int upperStockCodeLimit = 9999999, int previousBatches = 0)
        {
            var apiHelper = new WoolworthsApiService();
            await apiHelper.InitializeSession();
            Random random = new Random();
            int batchNo = 1;
            int batchSuccessNo = 0;
            if (previousBatches > 0)
                batchNo = previousBatches + 1;
            
            PrintService.PrintInfo($"Starting product batch {batchNo}");
            List<Barcodes> barcodes = new List<Barcodes>();
            List<VendorStockCode> vendorStockCodes = new List<VendorStockCode>();
            List<WoolworthsProduct> woolworthsProducts = new List<WoolworthsProduct>();
            
            for (int batch = 0; batch < 10; batch++)
            {

                HashSet<int> stockCodesSet = new HashSet<int>();

                while (stockCodesSet.Count < 100)
                {
                    int stockCode = random.Next(lowerStockCodeLimit, upperStockCodeLimit);
                    if (!stockCodesSet.Contains(stockCode))
                    {
                        stockCodesSet.Add(stockCode);
                    }
                }

                List<int> stockCodes = stockCodesSet.ToList();
                PrintService.PrintInfo($"Starting batch {batchNo} with the following stock codes\n{string.Join(", ", stockCodes)}\n");
                PrintService.PrintInfo($"Checking batch {batchNo} for valid stock codes");
                List<WooliesSbCodeIndex> indexValues = await apiHelper.RequestProductsForIndexingAsync(stockCodes);
                PrintService.PrintInfo($"Discarded {100 - indexValues.Count} invalid stock codes. Checking the following valid stock codes\n{string.Join(", ", indexValues.Select(iv => iv.Stockcode))}");

                Console.WriteLine();
                foreach (WooliesSbCodeIndex indexValue in indexValues)
                {
                    if (indexValue != null && indexValue.Stockcode > 0 && !string.IsNullOrEmpty(indexValue.Barcode))
                    {
                        
                        barcodes.Add(new Barcodes(indexValue));
                        vendorStockCodes.Add(new VendorStockCode(indexValue));
                        WooliesApiProduct apiProduct = await apiHelper.RequestProductAsync(indexValue.Stockcode);
                        PrintService.PrintInfo($"Checking product for stock code {indexValue.Stockcode}");
                        await Task.Delay(50);
                        WoolworthsProduct product = new WoolworthsProduct(apiProduct, indexValue.Stockcode);
                        if (!string.IsNullOrEmpty(product.SapDepartment) && product.SapDepartment.Length >= 1 && !string.IsNullOrEmpty(product.Name))
                        {
                            woolworthsProducts.Add(product);
                            PrintService.PrintSuccess($"Found entry for stock code {indexValue.Stockcode}");
                            PrintService.PrintInfo($"{product.Name} - {product.FullDescription.Substring(0, Math.Min(50, product.FullDescription.Length))}");
                            batchSuccessNo++;
                        }
                        else
                            PrintService.PrintFailure($"No valid product found for {indexValue.Stockcode}");
                        Console.WriteLine();
                    }
                }
                PrintService.PrintInfo($"Batch block: {batchNo}\tValid: {batchSuccessNo}\tInvalid: {100 - batchSuccessNo}");
                batchNo++;
            }
            PrintService.PrintInfo($"Saving {barcodes.Count} barcodes to database...");
            await WoolworthsSqlService.SaveBarcodesToIndexAsync(barcodes);
            PrintService.PrintSuccess($"Done.");

            PrintService.PrintInfo($"Saving {vendorStockCodes.Count} barcode/stock code index values to database...");
            await WoolworthsSqlService.SaveVendorCodesToIndexAsync(vendorStockCodes);
            PrintService.PrintSuccess($"Done.");

            PrintService.PrintInfo($"Saving {woolworthsProducts.Count} products to database...");
            await WoolworthsSqlService.SaveMultipleProductsAsync(woolworthsProducts);
            PrintService.PrintSuccess($"Done.");
        }
    
        public static async Task TrawlStockCodesBarcodesToIndexAsync(int lowerStockCodeLimit = 0, int upperStockCodeLimit = 9999999)
        {
            var apiHelper = new WoolworthsApiService();
            await apiHelper.InitializeSession();
            Random random = new Random();

            int batchNo = 1;

            while (true)
            {
                PrintService.PrintInfo($"Starting barcode index batch {batchNo}");
                List<Barcodes> barcodes = new List<Barcodes>();
                List<VendorStockCode> vendorStockCodes = new List<VendorStockCode>();
                int batchSuccessNo = 0;
                for (int batch = 0; batch < 10; batch++)
                {

                    HashSet<int> stockCodesSet = new HashSet<int>();

                    while (stockCodesSet.Count < 100)
                    {
                        int stockCode = random.Next(lowerStockCodeLimit, upperStockCodeLimit);
                        if (!stockCodesSet.Contains(stockCode))
                        {
                            stockCodesSet.Add(stockCode);
                        }
                    }

                    List<int> stockCodes = stockCodesSet.ToList();
                    await Task.Delay(1500);
                    List<WooliesSbCodeIndex> indexValues = await apiHelper.RequestProductsForIndexingAsync(stockCodes);

                    foreach (WooliesSbCodeIndex indexValue in indexValues)
                    {
                        if (indexValue != null && indexValue.Stockcode > 0 && !string.IsNullOrEmpty(indexValue.Barcode))
                        {
                            batchSuccessNo++;
                            barcodes.Add(new Barcodes(indexValue));
                            vendorStockCodes.Add(new VendorStockCode(indexValue));
                        }
                    }
                    PrintService.PrintInfo($"Batch block: {batch + 1}\tValid: {batchSuccessNo}");
                }
                PrintService.PrintInfo($"Saving {barcodes.Count} barcodes to database...");
                await WoolworthsSqlService.SaveBarcodesToIndexAsync(barcodes);
                PrintService.PrintSuccess($"Done.");

                PrintService.PrintInfo($"Saving {vendorStockCodes.Count} barcode/stock code index values to database...");
                await WoolworthsSqlService.SaveVendorCodesToIndexAsync(vendorStockCodes);
                PrintService.PrintSuccess($"Done.");
                batchNo++;
            }
        }

    }
}
