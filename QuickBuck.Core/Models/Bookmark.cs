using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class Bookmark:BaseEntity
    {
        public int JobSeekerId { get; set; }
        public int JobPostId { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public JobPost JobPost { get; set; }
        public string Title { get; set; }
    }
}
