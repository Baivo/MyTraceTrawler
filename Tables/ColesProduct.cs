using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraceTrawler.Tables
{
    public class ColesProduct
    {
        public string ColesProductId { get; set; } = Guid.NewGuid().ToString();
        public DateTime EntryDate = DateTime.Now;
        public string? Name { get; set; }
        public bool Active { get; set; }
        public string? StockCode { get; set; }
        public string? Brand { get; set; }
        public string? BrandExternalId { get; set; }
        public string[]? EANs { get; set; }
        public string[]? ManufacturerPartNumbers { get; set; }
        public string[]? UPCs { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProductPageUrl { get; set; }
    }
    public class ColesProductResponsePage
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int TotalResults { get; set; }
        public string? Locale { get; set; }
        public ColesProductResult[]? Results { get; set; }
        public ColesProductIncludes? Includes { get; set; }
        public bool HasErrors { get; set; }
        public object[]? Errors { get; set; }
    }

    public class ColesProductIncludes
    {
    }

    public class ColesProductResult
    {
        public string[]? EANs { get; set; }
        public string[]? AttributesOrder { get; set; }
        public ColesProductAttributes? Attributes { get; set; }
        public string[]? ManufacturerPartNumbers { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Id { get; set; }
        public string? CategoryId { get; set; }
        public bool Active { get; set; }
        public string? ProductPageUrl { get; set; }
        public bool Disabled { get; set; }
        public object[]? ModelNumbers { get; set; }
        public object[]? StoryIds { get; set; }
        public object[]? ISBNs { get; set; }
        public object[]? QuestionIds { get; set; }
        public string? BrandExternalId { get; set; }
        public ColesProductBrand? Brand { get; set; }
        public object? Description { get; set; }
        public object[]? ReviewIds { get; set; }
        public object[]? FamilyIds { get; set; }
        public string[]? UPCs { get; set; }
    }

    public class ColesProductAttributes
    {
        public ColesProductAttributeAvailability? Availability { get; set; }
    }

    public class ColesProductAttributeAvailability
    {
        public string? Id { get; set; }
        public ColesProductAvailabilityValues[]? Values { get; set; }
    }

    public class ColesProductAvailabilityValues
    {
        public string? Value { get; set; }
        public object? Locale { get; set; }
    }

    public class ColesProductBrand
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}