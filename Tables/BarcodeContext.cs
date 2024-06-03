using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;

namespace WooliesScraper.Tables
{
    public class BarcodeContext : DbContext
    {
        public DbSet<Barcodes> Barcodes { get; set; }
        public DbSet<StockCodes> StockCodes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Program._connectionString);
        }
    }

    public class Barcodes
    {
        public int Barcode { get; set; }
        public List<StockCodes> StockCodes { get; set; } = [];
    }
    public class StockCodes
    {
        public int Barcode { get; set; }
        public int StockCode { get; set; }
        public string VendorName { get; set; } = string.Empty;
    }
    
    public class BarcodeQueries
    {
        public static void QueryBarcodesByStockID(int stockID)
        {
            using (var db = new BarcodeContext())
            {
                List<StockCodes> stockCodes = db.StockCodes.Where(s => s.StockCode == stockID).ToList();
                foreach (var entry in stockCodes)
                {
                    Console.WriteLine("{1} {2} {3}", entry.StockCode, entry.Barcode, entry.VendorName);
                }
            }
        }

        public static void QueryStockCodesByBarcode(int barcode)
        {
            using (var db = new BarcodeContext())
            {
                var barcodeEntry = db.Barcodes.Where(b => b.Barcode == barcode).ToList().FirstOrDefault();
                if (barcodeEntry != null)
                {
                    Console.WriteLine($"Stock codes found for {barcode}");
                    foreach (StockCodes stockCode in barcodeEntry.StockCodes)
                    {
                        Console.WriteLine("{1} {2}", stockCode.StockCode, stockCode.VendorName);
                    }
                }
                else
                {
                    Console.WriteLine($"No stock codes found for {barcode}");
                }
            }
        }
    }
}
