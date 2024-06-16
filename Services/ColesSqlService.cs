using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using MyTraceTrawler.Tables;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraceTrawler.Services
{
    public static class ColesSqlService
    {
        
        public static ColesProduct? GetProductByStockCode(string stockCode)
        {
            using (var db = new DatabaseContext())
                return db.ColesProducts.Where(p => p.StockCode == stockCode).FirstOrDefault();
        }
        public static async Task SaveProductsAsync(List<ColesProduct> colesProducts)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.ColesProducts.AddRange(colesProducts);
                    await db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException dbEx)
            {
                PrintService.PrintDbError(dbEx);
            }
            catch (Exception ex)
            {
                PrintService.PrintError(ex);
            }
        }
        public static async Task SaveBrandsAsync(List<ColesBrand> colesBrands)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.ColesBrands.AddRange(colesBrands);
                    await db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException dbEx)
            {
                PrintService.PrintDbError(dbEx);
            }
            catch (Exception ex)
            {
                PrintService.PrintError(ex);
            }
        }
    }
}
