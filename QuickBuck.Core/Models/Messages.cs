using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public int JobSeekerId { get; set; }
        public int JobProviderId { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public JobProvider JobProvider { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
