using MyTraceTrawler.Services;

namespace MyTraceTrawler.Tables
{
    public class Barcodes
    {
        public string BarcodesId { get; set; }
        public Barcodes() 
        {
            BarcodesId = Guid.NewGuid().ToString();
        }
        public Barcodes(WooliesSbCodeIndex wooliesSbCodeIndex) 
        {
            BarcodesId = wooliesSbCodeIndex.Barcode;
        }
    }
    public class VendorStockCode
    {
        public string VendorStockCodeId { get; set; } 
        public int StockCode { get; set; } 
        public string Barcode { get; set; } = string.Empty;
        public string VendorName { get; set; } = string.Empty;

        public VendorStockCode() 
        {
            VendorStockCodeId = Guid.NewGuid().ToString();
        }

        public VendorStockCode(WooliesSbCodeIndex wooliesSbCodeIndex)
        {
            VendorStockCodeId = Guid.NewGuid().ToString();
            StockCode = wooliesSbCodeIndex.Stockcode;
            Barcode = wooliesSbCodeIndex.Barcode;
            VendorName = "Woolworths";
        }

    }


}