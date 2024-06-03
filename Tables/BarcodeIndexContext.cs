using Microsoft.EntityFrameworkCore;

namespace WooliesScraper.Tables
{
    public class BarcodeIndexContext : DbContext
    {
        public DbSet<Barcode> Barcode { get; set; }
        public DbSet<VendorStockCode> StockCodes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Program._connectionString);
        }
    }

    public class Barcode
    {
        public int BarcodeId { get; set; }
        public List<VendorStockCode> StockCodes { get; set; } = [];
    }
    public class VendorStockCode
    {
        public int VendorStockCodeId { get; set; }
        public int Barcode { get; set; }
        public string VendorName { get; set; } = string.Empty;
    }

    public class BarcodeQueries
    {
        public static void QueryBarcodesByStockID(int stockID)
        {
            using (var db = new BarcodeIndexContext())
            {
                List<VendorStockCode> stockCodes = db.StockCodes.Where(s => s.VendorStockCodeId == stockID).ToList();
                foreach (var entry in stockCodes)
                {
                    Console.WriteLine("{1} {2} {3}", entry.VendorStockCodeId, entry.Barcode, entry.VendorName);
                }
            }
        }

        public static void QueryStockCodeByBarcode(int barcode)
        {
            using (var db = new BarcodeIndexContext())
            {
                var barcodeEntry = db.Barcode.Where(b => b.BarcodeId == barcode).ToList().FirstOrDefault();
                if (barcodeEntry != null)
                {
                    Console.WriteLine($"Stock codes found for {barcode}");
                    foreach (VendorStockCode stockCode in barcodeEntry.StockCodes)
                    {
                        Console.WriteLine("{1} {2}", stockCode.VendorStockCodeId, stockCode.VendorName);
                    }
                }
                else
                {
                    Console.WriteLine($"No stock codes found for {barcode}");
                }
            }
        }
        public static async Task<int> QueryStockCodeByBarcodeAsync(int barcode, Vendor vendor)
        {
            await Task.CompletedTask;
            return 0;
        }
        public static void Migrate()
        {
            using (var db = new BarcodeIndexContext())
            {
                
            }
        }
    }
}