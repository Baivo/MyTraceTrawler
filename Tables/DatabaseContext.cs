using Microsoft.EntityFrameworkCore;
using System;

namespace MyTraceTrawler.Tables
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Barcodes> Barcode { get; set; }
        public DbSet<VendorStockCode> StockCodes { get; set; }
        public DbSet<WoolworthsProduct> Products { get; set; }
        public DbSet<ColesProduct> ColesProducts { get; set; }
        public DbSet<ColesBrand> ColesBrands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                Program._connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });
        }
    }
}
