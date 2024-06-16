using MyTraceTrawler.Services;

namespace MyTraceTrawler.Tables
{

    public class WoolworthsProduct
    {
        // Basics
        public string WoolworthsProductId { get; set; } = Guid.NewGuid().ToString();
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

        public WoolworthsProduct(WooliesApiProduct product, int stockCode)
        {
            Barcode = product?.Product?.Barcode ?? string.Empty;
            StockCode = stockCode;
            Name = product?.Product?.Name ?? string.Empty;
            DisplayName = product?.Product?.DisplayName ?? string.Empty;
            Description = product?.Product?.Description ?? string.Empty;
            Brand = product?.Product?.Brand ?? string.Empty;
            Ingredients = product?.AdditionalAttributes?.Ingredients ?? string.Empty;
            NutritionalInformation = product?.AdditionalAttributes?.Nutritionalinformation ?? string.Empty;
            SapDepartment = product?.AdditionalAttributes?.Sapdepartmentname ?? string.Empty;
            SapCategory = product?.AdditionalAttributes?.Sapcategoryname ?? string.Empty;
            SapSubCategory = product?.AdditionalAttributes?.Sapsubcategoryname ?? string.Empty;
            SapSegment = product?.AdditionalAttributes?.Sapsegmentname ?? string.Empty;
            SmallImageFile = product?.Product?.SmallImageFile ?? string.Empty;
            MediumImageFile = product?.Product?.MediumImageFile ?? string.Empty;
            LargeImageFile = product?.Product?.LargeImageFile ?? string.Empty;
            CupPrice = product?.Product?.CupPrice ?? 0;
            InStoreCupPrice = product?.Product?.InstoreCupPrice ?? 0;
            CupMeasure = product?.Product?.CupMeasure ?? string.Empty;
            CupString = product?.Product?.CupString ?? string.Empty;
            InStoreCupString = product?.Product?.InstoreCupString ?? string.Empty;
            HasCupPrice = product?.Product?.HasCupPrice ?? false;
            HasInStoreCupPrice = product?.Product?.InstoreHasCupPrice ?? false;
            Price = product?.Product?.Price ?? 0;
            InStorePrice = product?.Product?.InstorePrice ?? 0;
            SavingsAmount = product?.Product?.SavingsAmount ?? 0;
            InStoreSavingsAmount = product?.Product?.InstoreSavingsAmount ?? 0;
            WasPrice = product?.Product?.WasPrice ?? 0;
            InStoreWasPrice = product?.Product?.InstoreWasPrice ?? 0;
            IsNew = product?.Product?.IsNew ?? false;
            IsHalfPrice = product?.Product?.IsHalfPrice ?? false;
            IsOnlineOnly = product?.Product?.IsOnlineOnly ?? false;
            IsOnSpecial = product?.Product?.IsOnSpecial ?? false;
            IsInStoreOnSpecial = product?.Product?.InstoreIsOnSpecial ?? false;
            IsEdrSpecial = product?.Product?.IsEdrSpecial ?? false;
            IsRanged = product?.Product?.IsRanged ?? false;
            IsInStock = product?.Product?.IsInStock ?? false;
            IsPmDelivery = product?.Product?.IsPmDelivery ?? false;
            IsForCollection = product?.Product?.IsForCollection ?? false;
            IsForDelivery = product?.Product?.IsForDelivery ?? false;
            IsForExpress = product?.Product?.IsForExpress ?? false;
            IsAvailable = product?.Product?.IsAvailable ?? false;
            IsInStoreAvailable = product?.Product?.InstoreIsAvailable ?? false;
            IsPurchaseable = product?.Product?.IsAvailable ?? false;
            IsInStorePurchaseable = product?.Product?.InstoreIsPurchasable ?? false;
            IsAgeRestricted = product?.Product?.AgeRestricted ?? false;
            IsRestrictedByDeliveryMethod = product?.Product?.IsRestrictedByDeliveryMethod ?? false;
            IsSponsoredAd = product?.Product?.IsSponsoredAd ?? false;
            IsMarketProduct = product?.Product?.IsMarketProduct ?? false;
            IsGiftable = product?.Product?.IsGiftable ?? false;
            IsUntraceable = product?.Product?.Untraceable ?? false;
            IsTobacco = product?.Product?.IsTobacco ?? false;
            IsAddedVitaminsAndMinerals = product?.Product?.AdditionalAttributes?.Addedvitaminsandminerals?.Length > 0;
            IsMicrowaveable = product?.AdditionalAttributes?.Microwaveable == "True";
            IsMicrowaveSafe = product?.AdditionalAttributes?.Microwavesafe == "True";
            IsExcludedFromSubstitution = product?.AdditionalAttributes?.Isexcludedfromsubstitution == "True";
            IsParabenFree = product?.AdditionalAttributes?.Parabenfree == "True";
            IsContainGluten = product?.AdditionalAttributes?.Containsgluten == "True";
            IsContainNuts = product?.AdditionalAttributes?.Containsnuts == "True";
            IsAntibacterial = product?.AdditionalAttributes?.Antibacterial == "True";
            IsAntiseptic = product?.AdditionalAttributes?.Antiseptic == "True";
            IsBPAFree = product?.AdditionalAttributes?.Bpafree == "True";
            IsAntioxidant = product?.AdditionalAttributes?.Antioxidant == "True";
            IsSulfateFree = product?.AdditionalAttributes?.Sulfatefree == "True";
            IsOvenCook = product?.AdditionalAttributes?.Ovencook == "True";
            IsVegetarian = product?.AdditionalAttributes?.Vegetarian == "True";
            IsFreezable = product?.AdditionalAttributes?.Freezable == "True";
            Unit = product?.Product?.Unit ?? string.Empty;
            PackageSize = product?.Product?.PackageSize ?? string.Empty;
            UnitWeightInGrams = product?.Product?.UnitWeightInGrams ?? 0;
            DisplayQuantity = product?.Product?.DisplayQuantity ?? 0;
            RestrictionMessage = product?.Product?.ProductRestrictionMessage ?? string.Empty;
            WarningMessage = product?.Product?.ProductWarningMessage ?? string.Empty;
            SmallFormatDescription = product?.Product?.SmallFormatDescription ?? string.Empty;
            FullDescription = product?.Product?.FullDescription ?? string.Empty;
            Variety = product?.Product?.Variety ?? string.Empty;
            LifestyleAndDietaryStatement = product?.AdditionalAttributes?.Lifestyleanddietarystatement ?? string.Empty;
            AllergyStatement = product?.AdditionalAttributes?.Allergystatement ?? string.Empty;
            double hsr = 0;
            double.TryParse(product?.AdditionalAttributes?.Healthstarrating, out hsr);
            HealthStarRating = hsr;
            SuitableFor = product?.AdditionalAttributes?.Suitablefor ?? string.Empty;
            LifestyleClaim = product?.AdditionalAttributes?.Lifestyleclaim ?? string.Empty;
            TgaWarning = product?.AdditionalAttributes?.Tgawarning ?? string.Empty;
            TgaWarningUrl = product?.AdditionalAttributes?.Tgahealthwarninglink ?? string.Empty;
            AllergenMayBePresent = product?.AdditionalAttributes?.Allergenmaybepresent ?? string.Empty;
            StorageInstructions = product?.AdditionalAttributes?.Storageinstructions ?? string.Empty;
            NextAvailabilityDate = product?.Product?.NextAvailabilityDate;
            CountryOfOrigin = product?.CountryOfOriginLabel?.CountryOfOrigin ?? string.Empty;
            CountryOfOriginAltText = product?.CountryOfOriginLabel?.AltText ?? string.Empty;
            double igp = 0;
            double.TryParse(product?.CountryOfOriginLabel?.IngredientPercentage, out igp);
            CountryOfOriginIngredientPercentage = igp;
            CountryOfOriginDisclaimer = product?.CountryOfOriginLabel?.Disclaimer ?? string.Empty;
        }
        
        public WoolworthsProduct()
        {

        }
        
    }
}
