using QuickBuck.Core.Models;

namespace QuickBuck.DTOs
{
    public class JobPostDTO
    {
        public string Title { get; set; }
        public List<RequiredSkills> RequiredSkills { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public List<Requirements> Requirements { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public decimal SalaryRangeFrom { get; set; }
        public decimal SalaryRangeTo { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Applicants { get; set; }
        public int Viewed { get; set; }
        public int InConsideration { get; set; }
        public string Content { get; set; }
    }
}
