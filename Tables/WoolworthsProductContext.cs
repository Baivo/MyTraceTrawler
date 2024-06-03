using Microsoft.EntityFrameworkCore;
using WooliesScraper.Products;

namespace WooliesScraper.Tables
{
    public class WoolworthsProductContext : DbContext
    {
        public DbSet<WoolworthsProduct> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Program._connectionString);
        }
    }

    public class WoolworthsProduct
    {
        // Basics
        public string ProductId { get; set; } = Guid.NewGuid().ToString();
        public DateTime EntryDate = DateTime.Now;
        public string Barcode { get; set; } = string.Empty;
        public int StockCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public string NutritionalInformation { get; set; } = string.Empty; // Check Additional Attributes first

        //-------

        // SAP
        public string SapDepartment { get; set; } = string.Empty;
        public string SapCategory { get; set; } = string.Empty;
        public string SapSubCategory { get; set; } = string.Empty;
        public string SapSegment { get; set; } = string.Empty;
        //-------

        // Image Files
        public string SmallImageFile { get; set; } = string.Empty;
        public string MediumImageFile { get; set; } = string.Empty;
        public string LargeImageFile {  get; set; } = string.Empty;
        //-------

        // Cup Information
        public double CupPrice { get; set; }
        public double InStoreCupPrice { get; set; }
        public string CupMeasure { get; set; } = string.Empty;
        public string CupString { get; set; } = string.Empty;
        public string InStoreCupString { get; set; } = string.Empty;
        public bool HasCupPrice { get; set; }
        public bool HasInStoreCupPrice { get;set; }
        //-------

        // Price Information
        public double Price { get; set; }
        public double InStorePrice { get; set; }
        public double SavingsAmount { get; set; }
        public double InStoreSavingsAmount { get; set; }
        public double WasPrice { get; set; }
        public double InStoreWasPrice { get; set; }
        //-------

        // Bools
        public bool IsNew { get; set; }
        public bool IsHalfPrice { get; set; }
        public bool IsOnlineOnly { get; set; }
        public bool IsOnSpecial { get; set; }
        public bool IsInStoreOnSpecial { get; set; }
        public bool IsEdrSpecial { get; set; }
        public bool IsRanged { get; set; }
        public bool IsInStock { get; set; }
        public bool IsPmDelivery { get; set; }
        public bool IsForCollection { get; set; }
        public bool IsForDelivery { get; set; }
        public bool IsForExpress { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsInStoreAvailable { get; set; }
        public bool IsPurchaseable { get; set; }
        public bool IsInStorePurchaseable { get; set; }
        public bool IsAgeRestricted { get; set; }
        public bool IsRestrictedByDeliveryMethod { get; set; }
        public bool IsSponsoredAd { get; set; }
        public bool IsMarketProduct { get; set; }
        public bool IsGiftable { get; set; }
        public bool IsUntraceable { get; set; }
        public bool IsTobacco { get; set; }
        public bool IsAddedVitaminsAndMinerals { get; set; } = false;
        public bool IsMicrowaveSafe { get; set; }
        public bool IsMicrowaveable { get; set; }
        public bool IsExcludedFromSubstitution { get; set; }
        public bool IsParabenFree { get; set; }
        public bool IsContainGluten { get; set; }
        public bool IsContainNuts { get; set; }
        public bool IsAntibacterial { get; set; }
        public bool IsAntiseptic { get; set; }
        public bool IsBPAFree { get; set; }
        public bool IsAntioxidant { get; set; }
        public bool IsSulfateFree { get; set; }
        public bool IsOvenCook { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsFreezable { get; set; }
        //-------

        //
        public string Unit { get; set; } = string.Empty;
        public string PackageSize { get; set; } = string.Empty;
        public int UnitWeightInGrams { get; set; }
        public int DisplayQuantity { get; set; }
        //-------

        //
        public string RestrictionMessage { get; set; } = string.Empty;
        public string WarningMessage { get; set; } = string.Empty;
        public string SmallFormatDescription { get;  set; } = string.Empty;
        public string FullDescription { get; set; } = string.Empty;
        public string Variety { get; set; } = string.Empty;
        public string LifestyleAndDietaryStatement { get; set; } = string.Empty;
        public string AllergyStatement { get; set; } = string.Empty;
        public double HealthStarRating { get; set; }
        public string SuitableFor { get; set; } = string.Empty;
        public string LifestyleClaim { get; set; } = string.Empty;
        public string TgaWarning { get; set; } = string.Empty;
        public string TgaWarningUrl { get; set;} = string.Empty;
        public string AllergenMayBePresent {  get; set; } = string.Empty;
        public string StorageInstructions { get; set;} = string.Empty;

        //-------

        // Date/Times
        public DateTime? NextAvailabilityDate { get; set; }
        //-------

        // Country of Origin
        public string CountryOfOrigin { get; set; } = string.Empty;
        public string CountryOfOriginAltText { get; set; } = string.Empty;
        public double CountryOfOriginIngredientPercentage { get; set; } 
        public string CountryOfOriginDisclaimer { get; set; } = string.Empty;

        public WoolworthsProduct(WooliesProduct product, int stockCode)
        {
            Barcode = product.Product.Barcode;
            StockCode = stockCode;
            Name = product.Product.Name;
            DisplayName = product.Product.DisplayName;
            Description = product.Product.Description;
            Brand = product.Product.Brand;
            Ingredients = product.AdditionalAttributes.Ingredients;
            NutritionalInformation = product.AdditionalAttributes.Nutritionalinformation;
            //
            SapDepartment = product.AdditionalAttributes.Sapdepartmentname;
            SapCategory = product.AdditionalAttributes.Sapcategoryname;
            SapSubCategory = product.AdditionalAttributes.Sapsubcategoryname;
            SapSegment = product.AdditionalAttributes.Sapsegmentname;
            //
            SmallImageFile = product.Product.SmallImageFile;
            MediumImageFile = product.Product.MediumImageFile;
            LargeImageFile = product.Product.LargeImageFile;
            //
            CupPrice = product.Product.CupPrice ?? 0;
            InStoreCupPrice = product.Product.InstoreCupPrice ?? 0;
            CupMeasure = product.Product.CupMeasure;
            CupString = product.Product.CupString;
            InStoreCupString = product.Product.InstoreCupString;
            HasCupPrice = product.Product.HasCupPrice ?? false;
            HasInStoreCupPrice = product.Product.InstoreHasCupPrice ?? false;
            //
            Price = product.Product.Price ?? 0;
            InStorePrice = product.Product.InstorePrice ?? 0;
            SavingsAmount = product.Product.SavingsAmount ?? 0;
            InStoreSavingsAmount = product.Product.InstoreSavingsAmount ?? 0;
            WasPrice = product.Product.WasPrice ?? 0;
            InStoreWasPrice = product.Product.InstoreWasPrice ?? 0;
            //
            IsNew = product.Product.IsNew ?? false;
            IsHalfPrice = product.Product.IsHalfPrice ?? false;
            IsOnlineOnly = product.Product.IsOnlineOnly ?? false;
            IsOnSpecial = product.Product.IsOnSpecial ?? false;
            IsInStoreOnSpecial = product.Product.InstoreIsOnSpecial ?? false;
            IsEdrSpecial = product.Product.IsEdrSpecial ?? false;
            IsRanged = product.Product.IsRanged ?? false;
            IsInStock = product.Product.IsInStock ?? false;
            IsPmDelivery = product.Product.IsPmDelivery ?? false;
            IsForCollection = product.Product.IsForCollection ?? false;
            IsForDelivery = product.Product.IsForDelivery ?? false;
            IsForExpress = product.Product.IsForExpress ?? false;
            IsAvailable = product.Product.IsAvailable ?? false;
            IsInStoreAvailable = product.Product.InstoreIsAvailable ?? false;
            IsPurchaseable = product.Product.IsAvailable ?? false;
            IsInStorePurchaseable = product.Product.InstoreIsPurchasable ?? false;
            IsAgeRestricted = product.Product.AgeRestricted ?? false;
            IsRestrictedByDeliveryMethod = product.Product.IsRestrictedByDeliveryMethod ?? false;
            IsSponsoredAd = product.Product.IsSponsoredAd ?? false;
            IsMarketProduct = product.Product.IsMarketProduct ?? false;
            IsGiftable = product.Product.IsGiftable ?? false;
            IsUntraceable = product.Product.Untraceable ?? false;
            IsTobacco = product.Product.IsTobacco ?? false;
            IsAddedVitaminsAndMinerals = product.Product.AdditionalAttributes.Addedvitaminsandminerals.Length > 0;
            IsMicrowaveable = product.AdditionalAttributes.Microwaveable == "True";
            IsMicrowaveSafe = product.AdditionalAttributes.Microwavesafe == "True";
            IsExcludedFromSubstitution = product.AdditionalAttributes.Isexcludedfromsubstitution == "True";
            IsParabenFree = product.AdditionalAttributes.Parabenfree == "True";
            IsContainGluten = product.AdditionalAttributes.Containsgluten == "True";
            IsContainNuts = product.AdditionalAttributes.Containsnuts == "True";
            IsAntibacterial = product.AdditionalAttributes.Antibacterial == "True";
            IsAntiseptic = product.AdditionalAttributes.Antiseptic == "True";
            IsBPAFree = product.AdditionalAttributes.Bpafree == "True";
            IsAntioxidant = product.AdditionalAttributes.Antioxidant == "True";
            IsSulfateFree = product.AdditionalAttributes.Sulfatefree == "True";
            IsOvenCook = product.AdditionalAttributes.Ovencook == "True";
            IsVegetarian = product.AdditionalAttributes.Vegetarian == "True";
            IsFreezable = product.AdditionalAttributes.Freezable == "True";
            //
            Unit = product.Product.Unit;
            PackageSize = product.Product.PackageSize;
            UnitWeightInGrams = product.Product.UnitWeightInGrams ?? 0;
            DisplayQuantity = product.Product.DisplayQuantity ?? 0;
            //
            RestrictionMessage = product.Product.ProductRestrictionMessage.ToString() ?? string.Empty;
            WarningMessage = product.Product.ProductWarningMessage.ToString() ?? string.Empty;
            SmallFormatDescription = product.Product.SmallFormatDescription ?? string.Empty;
            FullDescription = product.Product.FullDescription ?? string.Empty;
            Variety = product.Product.Variety ?? string.Empty;
            LifestyleAndDietaryStatement = product.AdditionalAttributes.Lifestyleanddietarystatement;
            AllergyStatement = product.AdditionalAttributes.Allergystatement.ToString() ?? string.Empty;
            double hsr = 0;
            double.TryParse(product.AdditionalAttributes.Healthstarrating, out hsr);
            HealthStarRating = hsr;
            SuitableFor = product.AdditionalAttributes.Suitablefor.ToString() ?? string.Empty;
            LifestyleClaim = product.AdditionalAttributes.Lifestyleclaim.ToString() ?? string.Empty;
            TgaWarning = product.AdditionalAttributes.Tgawarning.ToString() ?? string.Empty;
            TgaWarningUrl = product.AdditionalAttributes.Tgahealthwarninglink.ToString() ?? string.Empty;
            AllergenMayBePresent = product.AdditionalAttributes.Allergenmaybepresent.ToString() ?? string.Empty;
            StorageInstructions = product.AdditionalAttributes.Storageinstructions.ToString() ?? string.Empty;
            //
            NextAvailabilityDate = product.Product.NextAvailabilityDate;
            //
            CountryOfOrigin = product.CountryOfOriginLabel.CountryOfOrigin;
            CountryOfOriginAltText = product.CountryOfOriginLabel.AltText;
            double igp = 0;
            double.TryParse(product.CountryOfOriginLabel.IngredientPercentage, out igp);
            CountryOfOriginIngredientPercentage = igp;
            CountryOfOriginDisclaimer = product.CountryOfOriginLabel.Disclaimer.ToString() ?? string.Empty;
        }
        public WoolworthsProduct()
        {

        }
        public async void SaveAsync()
        {
            try
            {
                using (var db = new WoolworthsProductContext())
                {
                    await db.Products.AddAsync(this);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public WoolworthsProduct GetProductByBarcode(string barcode)
        {
            using (var db = new WoolworthsProductContext())
                return db.Products.Where(p => p.Barcode == barcode).OrderByDescending(pr => pr.EntryDate).FirstOrDefault() ?? new WoolworthsProduct();
        }
        public WoolworthsProduct GetProductByStockCode(int stockCode) 
        {
            using (var db = new WoolworthsProductContext())
                return db.Products.Where(p => p.StockCode == stockCode).FirstOrDefault() ?? new WoolworthsProduct();
            
        }
    }
}
