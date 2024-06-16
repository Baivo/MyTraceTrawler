using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraceTrawler.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barcode",
                columns: table => new
                {
                    BarcodesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcode", x => x.BarcodesId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    WoolworthsProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SapDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SapCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SapSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SapSegment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmallImageFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediumImageFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LargeImageFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CupPrice = table.Column<double>(type: "float", nullable: false),
                    InStoreCupPrice = table.Column<double>(type: "float", nullable: false),
                    CupMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CupString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InStoreCupString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasCupPrice = table.Column<bool>(type: "bit", nullable: false),
                    HasInStoreCupPrice = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    InStorePrice = table.Column<double>(type: "float", nullable: false),
                    SavingsAmount = table.Column<double>(type: "float", nullable: false),
                    InStoreSavingsAmount = table.Column<double>(type: "float", nullable: false),
                    WasPrice = table.Column<double>(type: "float", nullable: false),
                    InStoreWasPrice = table.Column<double>(type: "float", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsHalfPrice = table.Column<bool>(type: "bit", nullable: false),
                    IsOnlineOnly = table.Column<bool>(type: "bit", nullable: false),
                    IsOnSpecial = table.Column<bool>(type: "bit", nullable: false),
                    IsInStoreOnSpecial = table.Column<bool>(type: "bit", nullable: false),
                    IsEdrSpecial = table.Column<bool>(type: "bit", nullable: false),
                    IsRanged = table.Column<bool>(type: "bit", nullable: false),
                    IsInStock = table.Column<bool>(type: "bit", nullable: false),
                    IsPmDelivery = table.Column<bool>(type: "bit", nullable: false),
                    IsForCollection = table.Column<bool>(type: "bit", nullable: false),
                    IsForDelivery = table.Column<bool>(type: "bit", nullable: false),
                    IsForExpress = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsInStoreAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsPurchaseable = table.Column<bool>(type: "bit", nullable: false),
                    IsInStorePurchaseable = table.Column<bool>(type: "bit", nullable: false),
                    IsAgeRestricted = table.Column<bool>(type: "bit", nullable: false),
                    IsRestrictedByDeliveryMethod = table.Column<bool>(type: "bit", nullable: false),
                    IsSponsoredAd = table.Column<bool>(type: "bit", nullable: false),
                    IsMarketProduct = table.Column<bool>(type: "bit", nullable: false),
                    IsGiftable = table.Column<bool>(type: "bit", nullable: false),
                    IsUntraceable = table.Column<bool>(type: "bit", nullable: false),
                    IsTobacco = table.Column<bool>(type: "bit", nullable: false),
                    IsAddedVitaminsAndMinerals = table.Column<bool>(type: "bit", nullable: false),
                    IsMicrowaveSafe = table.Column<bool>(type: "bit", nullable: false),
                    IsMicrowaveable = table.Column<bool>(type: "bit", nullable: false),
                    IsExcludedFromSubstitution = table.Column<bool>(type: "bit", nullable: false),
                    IsParabenFree = table.Column<bool>(type: "bit", nullable: false),
                    IsContainGluten = table.Column<bool>(type: "bit", nullable: false),
                    IsContainNuts = table.Column<bool>(type: "bit", nullable: false),
                    IsAntibacterial = table.Column<bool>(type: "bit", nullable: false),
                    IsAntiseptic = table.Column<bool>(type: "bit", nullable: false),
                    IsBPAFree = table.Column<bool>(type: "bit", nullable: false),
                    IsAntioxidant = table.Column<bool>(type: "bit", nullable: false),
                    IsSulfateFree = table.Column<bool>(type: "bit", nullable: false),
                    IsOvenCook = table.Column<bool>(type: "bit", nullable: false),
                    IsVegetarian = table.Column<bool>(type: "bit", nullable: false),
                    IsFreezable = table.Column<bool>(type: "bit", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitWeightInGrams = table.Column<int>(type: "int", nullable: false),
                    DisplayQuantity = table.Column<int>(type: "int", nullable: false),
                    RestrictionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarningMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmallFormatDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Variety = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifestyleAndDietaryStatement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllergyStatement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthStarRating = table.Column<double>(type: "float", nullable: false),
                    SuitableFor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifestyleClaim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TgaWarning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TgaWarningUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllergenMayBePresent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextAvailabilityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryOfOriginAltText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryOfOriginIngredientPercentage = table.Column<double>(type: "float", nullable: false),
                    CountryOfOriginDisclaimer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.WoolworthsProductId);
                });

            migrationBuilder.CreateTable(
                name: "StockCodes",
                columns: table => new
                {
                    VendorStockCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<int>(type: "int", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarcodesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCodes", x => x.VendorStockCodeId);
                    table.ForeignKey(
                        name: "FK_StockCodes_Barcode_BarcodesId",
                        column: x => x.BarcodesId,
                        principalTable: "Barcode",
                        principalColumn: "BarcodesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockCodes_BarcodesId",
                table: "StockCodes",
                column: "BarcodesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StockCodes");

            migrationBuilder.DropTable(
                name: "Barcode");
        }
    }
}
