using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class JobProvider:BaseEntity
    {
        
        public string CompanyName { get; set; }
        public string Location { get; set; }
        
        public string CompanySize { get; set; }
        public int NoOfEmployees { get; set; }
        public string Category { get; set; }
        public string? WebSite { get; set; }
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public Wallet Wallet { get; set; }
        public int WalletId { get; set; }
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification> ();
        public ICollection<JobApplication> JobApplications { get; set; } = new HashSet<JobApplication>();
        public ICollection<Messages> Messages { get; set; } = new HashSet<Messages>();
        public ICollection<Transactions> Transactions { get; set; } = new HashSet<Transactions>();
        public AppUser AppUser { get; set; }
    }
}
