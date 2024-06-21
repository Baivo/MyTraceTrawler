using MyTraceLib.Services;
using MyTraceLib.Tables;

namespace MyTraceTrawler.Trawlers
{
    public static class WoolworthsTrawler
    {

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
