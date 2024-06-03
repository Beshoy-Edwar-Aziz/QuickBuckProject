using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int JobProviderId { get; set; }
        public int JobSeekerId { get; set; }
        public int JobPostId { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public JobSeeker JobSeeker { get; set; }
        public JobProvider JobProvider { get; set; }
        public JobPost JobPost { get; set; }
    }
}
