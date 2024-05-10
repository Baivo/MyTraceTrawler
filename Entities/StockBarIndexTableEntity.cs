using Azure;
using Azure.Data.Tables;
using WooliesScraper.Products;

namespace WooliesScraper.Entities
{
    public class StockBarIndexTableEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
        public string StockCode { get; set; }
        public string BarCode { get; set; }
        public string Merchant { get; set; }

        public StockBarIndexTableEntity(WooliesProduct product)
        {
            PartitionKey = product.Product?.Barcode?.ToString() ?? "UnknownBarCode";
            RowKey = product.Product?.Stockcode.ToString() ?? "UnknownStockCode";
            StockCode = product.Product?.Stockcode.ToString() ?? "UnknownStockCode";
            BarCode = product.Product?.Barcode?.ToString() ?? "UnknownBarCode";
            Merchant = "Woolies";
        }
    }
}
