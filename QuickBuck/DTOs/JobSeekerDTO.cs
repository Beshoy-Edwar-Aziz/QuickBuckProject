using QuickBuck.Core.Models;

namespace QuickBuck.DTOs
{
    public class JobSeekerDTO
    {
        public string University { get; set; }
        public string College { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Photo { get; set; }
        public int CurrentYear { get; set; }
        public string Status { get; set; }
        public List<Skills> Skills { get; set; }
    }
}
