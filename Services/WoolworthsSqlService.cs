using Microsoft.EntityFrameworkCore;
using MyTraceTrawler.Tables;

namespace MyTraceTrawler.Services
{
    public static class WoolworthsSqlService
    {
        public static WoolworthsProduct GetProductByBarcode(string barcode)
        {
            using (var db = new DatabaseContext())
                return db.Products.Where(p => p.Barcode == barcode).OrderByDescending(pr => pr.EntryDate).FirstOrDefault() ?? new WoolworthsProduct();
        }
        public static WoolworthsProduct GetProductByStockCode(int stockCode)
        {
            using (var db = new DatabaseContext())
                return db.Products.Where(p => p.StockCode == stockCode).FirstOrDefault() ?? new WoolworthsProduct();
        }
        public static async Task SaveProductAsync(WoolworthsProduct product)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.Products.Add(product);
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
        public static async Task SaveMultipleProductsAsync(List<WoolworthsProduct> products)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    // Batch processing (optional)
                    int batchSize = 100; // Adjust as needed
                    for (int i = 0; i < products.Count; i += batchSize)
                    {
                        var batch = products.Skip(i).Take(batchSize).ToList();
                        await db.Products.AddRangeAsync(batch);
                        await db.SaveChangesAsync();
                    }
                }
            }
            catch(DbUpdateException dbEx)
            {
                PrintService.PrintDbError(dbEx);
            }
            catch (Exception ex)
            {
                PrintService.PrintError(ex);
            }
        }
        public static async Task<List<WoolworthsProduct>> GetMatchingProductsAsync(string sapDepartment, string sapCategory, string sapSubCategory, string sapSegment)
        {
            using (var db = new DatabaseContext())
            {
                var query = db.Products.AsQueryable();

                if (!string.IsNullOrEmpty(sapDepartment) && sapDepartment != "0")
                {
                    query = query.Where(p => p.SapDepartment == sapDepartment);
                }

                if (!string.IsNullOrEmpty(sapCategory) && sapCategory != "0")
                {
                    query = query.Where(p => p.SapCategory == sapCategory);
                }

                if (!string.IsNullOrEmpty(sapSubCategory) && sapSubCategory != "0")
                {
                    query = query.Where(p => p.SapSubCategory == sapSubCategory);
                }

                if (!string.IsNullOrEmpty(sapSegment) && sapSegment != "0")
                {
                    query = query.Where(p => p.SapSegment == sapSegment);
                }

                return await query.ToListAsync();
            }
        }
        public static async Task<List<WoolworthsProduct>> GetMatchingProductsAsync(WoolworthsProduct product)
        {
            using (var db = new DatabaseContext())
            {
                var query = db.Products.AsQueryable();

                if (!string.IsNullOrEmpty(product.SapDepartment) && product.SapDepartment != "0")
                {
                    query = query.Where(p => p.SapDepartment == product.SapDepartment);
                }

                if (!string.IsNullOrEmpty(product.SapCategory) && product.SapCategory != "0")
                {
                    query = query.Where(p => p.SapCategory == product.SapCategory);
                }

                if (!string.IsNullOrEmpty(product.SapSubCategory) && product.SapSubCategory != "0")
                {
                    query = query.Where(p => p.SapSubCategory == product.SapSubCategory);
                }

                if (!string.IsNullOrEmpty(product.SapSegment) && product.SapSegment != "0")
                {
                    query = query.Where(p => p.SapSegment == product.SapSegment);
                }
                return await query.ToListAsync();
            }
        }

        public static async Task SaveBarcodesToIndexAsync(List<Barcodes> barcodes)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    var barcodeIds = barcodes.Select(b => b.BarcodesId).ToList();

                    // Fetch existing barcodes that match the input barcode IDs with AsNoTracking()
                    var existingBarcodes = await db.Barcode
                        .Where(b => barcodeIds.Contains(b.BarcodesId))
                        .AsNoTracking()
                        .ToListAsync();

                    var existingBarcodesIds = new HashSet<string>(existingBarcodes.Select(b => b.BarcodesId));
                    var newBarcodes = barcodes.Where(b => !existingBarcodesIds.Contains(b.BarcodesId)).ToList();

                    // Detach all existing entities to avoid tracking conflicts
                    db.ChangeTracker.Clear();

                    // Update existing barcodes in batch
                    foreach (var barcode in existingBarcodes)
                    {
                        var updateBarcode = barcodes.First(b => b.BarcodesId == barcode.BarcodesId);
                        barcode.BarcodesId = updateBarcode.BarcodesId;
                        db.Barcode.Update(barcode);
                    }

                    // Add new barcodes
                    if (newBarcodes.Count > 0)
                    {
                        await db.Barcode.AddRangeAsync(newBarcodes);
                    }

                    await db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException dbEx)
            {
                PrintService.PrintFailure("DbUpdateException: " + dbEx.Message);
                if (dbEx.InnerException != null)
                {
                    PrintService.PrintFailure("Inner Exception: " + dbEx.InnerException.Message);
                    PrintService.PrintFailure("Inner Exception Stack Trace: " + dbEx.InnerException.StackTrace);
                }
            }
            catch (Exception ex)
            {
                PrintService.PrintFailure("Exception: " + ex.Message);
                PrintService.PrintFailure("Stack Trace: " + ex.StackTrace);
            }
            await Task.CompletedTask;
        }

        public static async Task SaveVendorCodesToIndexAsync(List<VendorStockCode> vendorStockCodes)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    var vendorStockCodeIds = vendorStockCodes.Select(v => v.VendorStockCodeId).ToList();

                    // Fetch existing vendor stock codes that match the input vendor stock code IDs with AsNoTracking()
                    var existingVendorStockCodes = await db.StockCodes
                        .Where(v => vendorStockCodeIds.Contains(v.VendorStockCodeId))
                        .AsNoTracking()
                        .ToListAsync();

                    var existingVendorStockCodeIds = new HashSet<string>(existingVendorStockCodes.Select(v => v.VendorStockCodeId));
                    var newVendorStockCodes = vendorStockCodes.Where(v => !existingVendorStockCodeIds.Contains(v.VendorStockCodeId)).ToList();

                    // Detach all existing entities to avoid tracking conflicts
                    db.ChangeTracker.Clear();

                    // Update existing vendor stock codes in batch
                    foreach (var vendorStockCode in existingVendorStockCodes)
                    {
                        var updateVendorStockCode = vendorStockCodes.First(v => v.VendorStockCodeId == vendorStockCode.VendorStockCodeId);
                        vendorStockCode.StockCode = updateVendorStockCode.StockCode;
                        vendorStockCode.Barcode = updateVendorStockCode.Barcode;
                        vendorStockCode.VendorName = updateVendorStockCode.VendorName;
                        db.StockCodes.Update(vendorStockCode);
                    }

                    // Add new vendor stock codes
                    if (newVendorStockCodes.Count > 0)
                    {
                        await db.StockCodes.AddRangeAsync(newVendorStockCodes);
                    }

                    await db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException dbEx)
            {
                PrintService.PrintFailure("DbUpdateException: " + dbEx.Message);
                if (dbEx.InnerException != null)
                {
                    PrintService.PrintFailure("Inner Exception: " + dbEx.InnerException.Message);
                    PrintService.PrintFailure("Inner Exception Stack Trace: " + dbEx.InnerException.StackTrace);
                }
            }
            catch (Exception ex)
            {
                PrintService.PrintFailure("Exception: " + ex.Message);
                PrintService.PrintFailure("Stack Trace: " + ex.StackTrace);
            }
            await Task.CompletedTask;
        }
    }
}
