using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class JobSeeker:BaseEntity
    {
        public JobSeeker()
        {
            
        }
        public JobSeeker(string university, string college, DateTime birthdate, string photo, int currentyear, string status, List<Skills> skill)
        {
            University = university;
            College = college;
            BirthDate = birthdate;
            Photo = photo;
            CurrentYear = currentyear;
            Status = status;
            Skills = skill;
        }
        public int Id { get; set; }
        public string University { get; set; }
        public string College { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Photo { get; set; }
        public int CurrentYear { get; set; }
        
        public string Status { get; set; }
        public bool Premium { get; set; } = false;
        public List<Skills> Skills { get; set; } 

        public Wallet Wallet { get; set; }
        public int WalletId { get; set; }
        public ICollection<Bookmark> Bookmarks { get; set; } = new HashSet<Bookmark>();
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public ICollection<JobApplication> JobApplications { get; set; } = new HashSet<JobApplication>();
        public ICollection<Messages> Messages { get; set; } = new HashSet<Messages>();
        public AppUser AppUser { get; set; }

    }
}
