namespace QuickBuck.DTOs
{
    public class JobProviderDTO
    {
        public string CompanyName { get; set; }
        public string Location { get; set; }

        public string CompanySize { get; set; }
        public int NoOfEmployees { get; set; } = 0;
        public string Category { get; set; }
        public string? WebSite { get; set; }
        public string? Logo { get; set; }
        public string? Description { get; set; }
    }
}
