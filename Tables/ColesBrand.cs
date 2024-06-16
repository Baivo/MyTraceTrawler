using Azure;

namespace MyTraceTrawler.Tables
{
    public class ColesBrand
    {
        public string ColesBrandId { get; set; } = Guid.NewGuid().ToString();
        public DateTime EntryDate = DateTime.Now;
        public string Name { get; set; }
        public string InternalId { get; set; }
    }
    
    public class ColesBrandResponsePage
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int TotalResults { get; set; }
        public string Locale { get; set; }
        public ColesBrandResult[] Results { get; set; }
        public ColesBrandIncludes Includes { get; set; }
        public bool HasErrors { get; set; }
        public object[] Errors { get; set; }
    }

    public class ColesBrandIncludes
    {
    }

    public class ColesBrandResult
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool Active { get; set; }
        public bool Disabled { get; set; }
        public object[] AttributesOrder { get; set; }
        public object[] ProductIds { get; set; }
        public ColesBrandAttributes Attributes { get; set; }
    }

    public class ColesBrandAttributes
    {
    }
}
