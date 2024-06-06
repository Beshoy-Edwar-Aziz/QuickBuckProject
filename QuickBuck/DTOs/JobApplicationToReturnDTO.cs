using QuickBuck.Core.Models;

namespace QuickBuck.DTOs
{
    public class JobApplicationToReturnDTO
    {
        public string CV { get; set; } //jobseeker will provide a link to his CV
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public string CoverLetter { get; set; } //same as CV
        public int JobPostId { get; set; }
        public int JobSeekerId { get; set; }
        public int JobProviderId { get; set; }
      
    }
}
