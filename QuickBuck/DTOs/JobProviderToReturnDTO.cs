using QuickBuck.Core.Models;

namespace QuickBuck.DTOs
{
    public class JobProviderToReturnDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public bool Premium { get; set; }
        public string CompanySize { get; set; }
        public int NoOfEmployees { get; set; } = 0;
        public string Category { get; set; }
        public string? WebSite { get; set; }
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public Wallet Wallet { get; set; }

    }
}
