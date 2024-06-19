using QuickBuck.Core.Models;

namespace QuickBuck.DTOs
{
    public class JobSeekerToReturnDTO
    {
        public int Id { get; set; }
        public string UserFName { get; set; }
        public string UserLName { get; set; }
        public string UserName { get; set; }
        public Address Address { get; set; }
        public string University { get; set; }
        public string College { get; set; }
        public Wallet Wallet { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Photo { get; set; }
        public int CurrentYear { get; set; }
        public string Status { get; set; }
        public List<Skills> Skills { get; set; }
    }
}
