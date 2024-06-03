using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class JobApplication:BaseEntity
    {
        public string CV { get; set; } //jobseeker will provide a link to his CV
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public string CoverLetter { get; set; } //same as CV
        public int JobSeekerId { get; set; }
        public int JobProviderId { get; set; }
        public int JobPostId { get; set; }
        public JobPost JobPost { get; set; }
        public JobProvider JobProvider { get; set; }
        public JobSeeker JobSeeker { get; set; }
    }
}
