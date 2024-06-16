﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyTraceTrawler.Tables;

#nullable disable

namespace MyTraceTrawler.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240604020006_Index")]
    partial class Index
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WooliesScraper.Tables.Barcodes", b =>
                {
                    b.Property<int>("BarcodesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BarcodesId"));

                    b.HasKey("BarcodesId");

                    b.ToTable("Barcode");
                });

            modelBuilder.Entity("WooliesScraper.Tables.VendorStockCode", b =>
                {
                    b.Property<int>("VendorStockCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorStockCodeId"));

                    b.Property<int>("Barcode")
                        .HasColumnType("int");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorStockCodeId");

                    b.ToTable("StockCodes");
                });

            modelBuilder.Entity("WooliesScraper.Tables.WoolworthsProduct", b =>
                {
                    b.Property<string>("WoolworthsProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AllergenMayBePresent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AllergyStatement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOriginAltText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOriginDisclaimer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CountryOfOriginIngredientPercentage")
                        .HasColumnType("float");

                    b.Property<string>("CupMeasure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CupPrice")
                        .HasColumnType("float");

                    b.Property<string>("CupString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayQuantity")
                        .HasColumnType("int");

                    b.Property<string>("FullDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasCupPrice")
                        .HasColumnType("bit");

                    b.Property<bool>("HasInStoreCupPrice")
                        .HasColumnType("bit");

                    b.Property<double>("HealthStarRating")
                        .HasColumnType("float");

                    b.Property<double>("InStoreCupPrice")
                        .HasColumnType("float");

                    b.Property<string>("InStoreCupString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("InStorePrice")
                        .HasColumnType("float");

                    b.Property<double>("InStoreSavingsAmount")
                        .HasColumnType("float");

                    b.Property<double>("InStoreWasPrice")
                        .HasColumnType("float");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAddedVitaminsAndMinerals")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAgeRestricted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAntibacterial")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAntioxidant")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAntiseptic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBPAFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsContainGluten")
                        .HasColumnType("bit");

                    b.Property<bool>("IsContainNuts")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEdrSpecial")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExcludedFromSubstitution")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForCollection")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForDelivery")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForExpress")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFreezable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGiftable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHalfPrice")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInStoreAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInStoreOnSpecial")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInStorePurchaseable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMarketProduct")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMicrowaveSafe")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMicrowaveable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnSpecial")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnlineOnly")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOvenCook")
                        .HasColumnType("bit");

                    b.Property<bool>("IsParabenFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPmDelivery")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPurchaseable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRanged")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRestrictedByDeliveryMethod")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSponsoredAd")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSulfateFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTobacco")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUntraceable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegetarian")
                        .HasColumnType("bit");

                    b.Property<string>("LargeImageFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LifestyleAndDietaryStatement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LifestyleClaim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediumImageFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NextAvailabilityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NutritionalInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RestrictionMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SapCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SapDepartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SapSegment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SapSubCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SavingsAmount")
                        .HasColumnType("float");

                    b.Property<string>("SmallFormatDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallImageFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockCode")
                        .HasColumnType("int");

                    b.Property<string>("StorageInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuitableFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TgaWarning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TgaWarningUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitWeightInGrams")
                        .HasColumnType("int");

                    b.Property<string>("Variety")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarningMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("WasPrice")
                        .HasColumnType("float");

                    b.HasKey("WoolworthsProductId");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
