using QuickBuck.Core.Models;

namespace QuickBuck.DTOs
{
    public class MessageToReturnDTO
    {
        public int Id { get; set; } 
        public int JobSeekerId { get; set; }
        public int JobProviderId { get; set; }
        public JobSeekerToReturnDTO JobSeeker { get; set; }
        public JobProviderToReturnDTO JobProvider { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
       
    }
}
