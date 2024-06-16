using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class Messages:BaseEntity
    {
        public int JobSeekerId { get; set; }
        public int JobProviderId { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public JobProvider JobProvider { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        
        
    }
}
