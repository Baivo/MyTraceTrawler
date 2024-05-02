using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooliesScraper.Products
{
    // WooliesProduct myDeserializedClass = JsonConvert.DeserializeObject<WooliesProduct>(myJsonResponse);
    public class AdditionalAttributes
    {
        public object Boxedcontents { get; set; }
        public string Addedvitaminsandminerals { get; set; }
        public string Sapdepartmentname { get; set; }
        public object Spf { get; set; }
        public object Haircolour { get; set; }
        public string Lifestyleanddietarystatement { get; set; }
        public string Sapcategoryname { get; set; }
        public object Skintype { get; set; }
        public object Importantinformation { get; set; }
        public object Allergystatement { get; set; }
        public object Productdepthmm { get; set; }
        public object Skincondition { get; set; }
        public object Ophthalmologistapproved { get; set; }
        public object Healthstarrating { get; set; }
        public object Hairtype { get; set; }

        [JsonProperty("fragrance-free")]
        public object FragranceFree { get; set; }
        public string Sapsegmentname { get; set; }
        public object Suitablefor { get; set; }
        public string PiesProductDepartmentsjson { get; set; }
        public string Piessubcategorynamesjson { get; set; }
        public string Sapsegmentno { get; set; }
        public object Productwidthmm { get; set; }
        public object Contains { get; set; }
        public string Sapsubcategoryname { get; set; }
        public object Dermatologisttested { get; set; }
        public object WoolProductpackaging { get; set; }
        public object Dermatologicallyapproved { get; set; }
        public object Specialsgroupid { get; set; }
        public string Productimages { get; set; }
        public object Productheightmm { get; set; }

        [JsonProperty("r&r_hidereviews")]
        public object RRHidereviews { get; set; }
        public string Microwavesafe { get; set; }

        [JsonProperty("paba-free")]
        public object PabaFree { get; set; }
        public object Lifestyleclaim { get; set; }
        public object Alcoholfree { get; set; }
        public object Tgawarning { get; set; }
        public object Activeconstituents { get; set; }
        public string Microwaveable { get; set; }

        [JsonProperty("soap-free")]
        public object SoapFree { get; set; }
        public object Countryoforigin { get; set; }
        public string Isexcludedfromsubstitution { get; set; }
        public string Productimagecount { get; set; }

        [JsonProperty("r&r_loggedinreviews")]
        public object RRLoggedinreviews { get; set; }

        [JsonProperty("anti-dandruff")]
        public object AntiDandruff { get; set; }

        [JsonProperty("servingsize-total-nip")]
        public object ServingsizeTotalNip { get; set; }
        public object Tgahealthwarninglink { get; set; }
        public string Allergenmaybepresent { get; set; }
        public string PiesProductDepartmentNodeId { get; set; }
        public string Parabenfree { get; set; }
        public object Vendorarticleid { get; set; }
        public string Containsgluten { get; set; }
        public string Containsnuts { get; set; }
        public string Ingredients { get; set; }
        public object Colour { get; set; }
        public object Manufacturer { get; set; }
        public string Sapcategoryno { get; set; }
        public object Storageinstructions { get; set; }
        public object Tgawarnings { get; set; }
        public string Piesdepartmentnamesjson { get; set; }
        public string Brand { get; set; }
        public object Oilfree { get; set; }
        public object Fragrance { get; set; }
        public string Antibacterial { get; set; }

        [JsonProperty("non-comedogenic")]
        public object NonComedogenic { get; set; }
        public string Antiseptic { get; set; }
        public string Bpafree { get; set; }
        public object Vendorcostprice { get; set; }
        public string Description { get; set; }
        public object Sweatresistant { get; set; }
        public string Sapsubcategoryno { get; set; }
        public string Antioxidant { get; set; }
        public object Claims { get; set; }
        public object Phbalanced { get; set; }
        public object WoolDietaryclaim { get; set; }
        public object Ophthalmologisttested { get; set; }
        public string Sulfatefree { get; set; }

        [JsonProperty("servingsperpack-total-nip")]
        public object ServingsperpackTotalNip { get; set; }
        public string Piescategorynamesjson { get; set; }
        public string Nutritionalinformation { get; set; }
        public string Ovencook { get; set; }
        public string Vegetarian { get; set; }

        [JsonProperty("hypo-allergenic")]
        public object HypoAllergenic { get; set; }
        public object Timer { get; set; }
        public object Dermatologistrecommended { get; set; }
        public string Sapdepartmentno { get; set; }
        public string Allergencontains { get; set; }
        public object Waterresistant { get; set; }
        public object Friendlydisclaimer { get; set; }
        public object Recyclableinformation { get; set; }
        public object Usageinstructions { get; set; }
        public string Freezable { get; set; }
    }

    public class CentreTag
    {
        public object TagContent { get; set; }
        public object TagLink { get; set; }
        public object FallbackText { get; set; }
        public string TagType { get; set; }
        public object MultibuyData { get; set; }
        public object MemberPriceData { get; set; }
        public object TagContentText { get; set; }
        public object DualImageTagContent { get; set; }
        public string PromotionType { get; set; }
        public bool? IsRegisteredRewardCardPromotion { get; set; }
    }

    public class CountryOfOriginLabel
    {
        public string PngImageFile { get; set; }
        public string SvgImageFile { get; set; }
        public string AltText { get; set; }
        public string CountryOfOrigin { get; set; }
        public string IngredientPercentage { get; set; }
        public object Disclaimer { get; set; }
    }

    public class FooterTag
    {
        public object TagContent { get; set; }
        public object TagLink { get; set; }
        public object FallbackText { get; set; }
        public string TagType { get; set; }
        public object MultibuyData { get; set; }
        public object MemberPriceData { get; set; }
        public object TagContentText { get; set; }
        public object DualImageTagContent { get; set; }
        public string PromotionType { get; set; }
        public bool? IsRegisteredRewardCardPromotion { get; set; }
    }

    public class ImageTag
    {
        public object TagContent { get; set; }
        public object TagLink { get; set; }
        public object FallbackText { get; set; }
        public string TagType { get; set; }
        public object MultibuyData { get; set; }
        public object MemberPriceData { get; set; }
        public object TagContentText { get; set; }
        public object DualImageTagContent { get; set; }
        public string PromotionType { get; set; }
        public bool? IsRegisteredRewardCardPromotion { get; set; }
    }

    public class NutritionalInformation
    {
        public string Name { get; set; }
        public Values Values { get; set; }
        public string ServingSize { get; set; }
        public string ServingsPerPack { get; set; }
    }

    public class PrimaryCategory
    {
        public string Department { get; set; }
        public string Aisle { get; set; }
        public int? VisualShoppingAisleId { get; set; }
        public int? DisplayOrder { get; set; }
        public object OverrideName { get; set; }
        public string Instance { get; set; }
    }

    public class Product
    {
        public int? TileID { get; set; }
        public int? Stockcode { get; set; }
        public string Barcode { get; set; }
        public int? GtinFormat { get; set; }
        public double? CupPrice { get; set; }
        public double? InstoreCupPrice { get; set; }
        public string CupMeasure { get; set; }
        public string CupString { get; set; }
        public string InstoreCupString { get; set; }
        public bool? HasCupPrice { get; set; }
        public bool? InstoreHasCupPrice { get; set; }
        public double? Price { get; set; }
        public double? InstorePrice { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string UrlFriendlyName { get; set; }
        public string Description { get; set; }
        public string SmallImageFile { get; set; }
        public string MediumImageFile { get; set; }
        public string LargeImageFile { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsHalfPrice { get; set; }
        public bool? IsOnlineOnly { get; set; }
        public bool? IsOnSpecial { get; set; }
        public bool? InstoreIsOnSpecial { get; set; }
        public bool? IsEdrSpecial { get; set; }
        public double? SavingsAmount { get; set; }
        public double? InstoreSavingsAmount { get; set; }
        public double? WasPrice { get; set; }
        public double? InstoreWasPrice { get; set; }
        public int? QuantityInTrolley { get; set; }
        public string Unit { get; set; }
        public int? MinimumQuantity { get; set; }
        public bool? HasBeenBoughtBefore { get; set; }
        public bool? IsInTrolley { get; set; }
        public string Source { get; set; }
        public int? SupplyLimit { get; set; }
        public int? ProductLimit { get; set; }
        public string MaxSupplyLimitMessage { get; set; }
        public bool? IsRanged { get; set; }
        public bool? IsInStock { get; set; }
        public string PackageSize { get; set; }
        public bool? IsPmDelivery { get; set; }
        public bool? IsForCollection { get; set; }
        public bool? IsForDelivery { get; set; }
        public bool? IsForExpress { get; set; }
        public object ProductRestrictionMessage { get; set; }
        public object ProductWarningMessage { get; set; }
        public CentreTag CentreTag { get; set; }
        public bool? IsCentreTag { get; set; }
        public ImageTag ImageTag { get; set; }
        public object HeaderTag { get; set; }
        public bool? HasHeaderTag { get; set; }
        public int? UnitWeightInGrams { get; set; }
        public string SupplyLimitMessage { get; set; }
        public string SmallFormatDescription { get; set; }
        public string FullDescription { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? InstoreIsAvailable { get; set; }
        public bool? IsPurchasable { get; set; }
        public bool? InstoreIsPurchasable { get; set; }
        public bool? AgeRestricted { get; set; }
        public int? DisplayQuantity { get; set; }
        public string RichDescription { get; set; }
        public bool? HideWasSavedPrice { get; set; }
        public SapCategories SapCategories { get; set; }
        public string Brand { get; set; }
        public bool? IsRestrictedByDeliveryMethod { get; set; }
        public FooterTag FooterTag { get; set; }
        public bool? IsFooterEnabled { get; set; }
        public string Diagnostics { get; set; }
        public bool? IsBundle { get; set; }
        public bool? IsInFamily { get; set; }
        public List<object> ChildProducts { get; set; }
        public object UrlOverride { get; set; }
        public AdditionalAttributes AdditionalAttributes { get; set; }
        public List<string> DetailsImagePaths { get; set; }
        public string Variety { get; set; }
        public Rating Rating { get; set; }
        public bool? HasProductSubs { get; set; }
        public bool? IsSponsoredAd { get; set; }
        public object AdID { get; set; }
        public object AdIndex { get; set; }
        public object AdStatus { get; set; }
        public bool? IsMarketProduct { get; set; }
        public bool? IsGiftable { get; set; }
        public object Vendor { get; set; }
        public bool? Untraceable { get; set; }
        public object ThirdPartyProductInfo { get; set; }
        public object MarketFeatures { get; set; }
        public object MarketSpecifications { get; set; }
        public string SupplyLimitSource { get; set; }
        public object Tags { get; set; }
        public bool? IsPersonalisedByPurchaseHistory { get; set; }
        public bool? IsFromFacetedSearch { get; set; }
        public DateTime? NextAvailabilityDate { get; set; }
        public int? NumberOfSubstitutes { get; set; }
        public bool? IsPrimaryVariant { get; set; }
        public int? VariantGroupId { get; set; }
        public bool? HasVariants { get; set; }
        public object VariantTitle { get; set; }
        public bool? IsTobacco { get; set; }
    }

    public class Rating
    {
        public int? ReviewCount { get; set; }
        public int? RatingCount { get; set; }
        public int? RatingSum { get; set; }
        public int? OneStarCount { get; set; }
        public int? TwoStarCount { get; set; }
        public int? ThreeStarCount { get; set; }
        public int? FourStarCount { get; set; }
        public int? FiveStarCount { get; set; }
        public int? Average { get; set; }
        public int? OneStarPercentage { get; set; }
        public int? TwoStarPercentage { get; set; }
        public int? ThreeStarPercentage { get; set; }
        public int? FourStarPercentage { get; set; }
        public int? FiveStarPercentage { get; set; }
    }

    public class RichRelevancePlacement
    {
        public object PlacementName { get; set; }
        public object Message { get; set; }
        public List<object> Products { get; set; }
        public List<object> Items { get; set; }
        public List<object> StockcodesForDiscover { get; set; }
    }

    public class WooliesProduct
    {
        public Product Product { get; set; }
        public object Nutrition { get; set; }
        public object VideoUrl { get; set; }
        public PrimaryCategory PrimaryCategory { get; set; }
        public AdditionalAttributes AdditionalAttributes { get; set; }
        public TgaAttributes TgaAttributes { get; set; }
        public List<string> DetailsImagePaths { get; set; }
        public List<NutritionalInformation> NutritionalInformation { get; set; }
        public List<RichRelevancePlacement> RichRelevancePlacements { get; set; }
        public List<object> Variants { get; set; }
        public List<object> VariantOptionGroups { get; set; }
        public bool? IsTobacco { get; set; }
        public CountryOfOriginLabel CountryOfOriginLabel { get; set; }
        public object DiagnosticsData { get; set; }
    }

    public class SapCategories
    {
        public string SapDepartmentName { get; set; }
        public string SapCategoryName { get; set; }
        public string SapSubCategoryName { get; set; }
        public string SapSegmentName { get; set; }
    }

    public class TgaAttributes
    {
        public object Directions { get; set; }
        public object ProductWarnings { get; set; }
        public object SuitableFor { get; set; }
        public object StorageInstructions { get; set; }
    }

    public class Values
    {
        [JsonProperty("Quantity Per Serving")]
        public string QuantityPerServing { get; set; }

        [JsonProperty("Quantity Per 100g / 100mL")]
        public string QuantityPer100g100mL { get; set; }
    }


}
