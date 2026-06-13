using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using QuickBuck.Repository.Data;
using QuickBuck.Repository.Specifications;

namespace QuickBuck.Helpers
{
    public class ChatHub:Hub
    {
        private readonly QuickBuckContext _context;
        private readonly ILogger<ChatHub> _logger;
        private readonly IGenericRepository<JobSeeker> _seekerRepo;
        private readonly IGenericRepository<JobProvider> _providerRepo;
        private readonly IGenericRepository<Messages> _messageRepo;

        public ChatHub(QuickBuckContext Context, ILogger<ChatHub> Logger, IGenericRepository<JobSeeker> SeekerRepo, IGenericRepository<JobProvider> ProviderRepo, IGenericRepository<Messages> MessageRepo)
        {
            _context = Context;
            _logger = Logger;
            _seekerRepo = SeekerRepo;
            _providerRepo = ProviderRepo;
            _messageRepo = MessageRepo;
        }
        public async Task JoinConversation(int JobSeekerId , int JobProviderId)
        {
            string groupName = GetGroupName(JobSeekerId, JobProviderId);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
        public async Task LeaveConversation (int JobSeekerId, int JobProviderId)
        {
            string groupName = GetGroupName(JobSeekerId, JobProviderId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
        public async Task Send(int JobSeekerId,int JobProviderId,string Context, string Role,string Name)
        {
            var SpecJobSeeker = new JobSeekerSpecWithIncludeAndCriteria(JobSeekerId);
            var JobSeeker = await _seekerRepo.GetWithSpecByIdAsync(SpecJobSeeker);
            var SpecJobProvider = new JobProviderWithIncludesAndCriteria(JobProviderId,null);
            var JobProvider = await _providerRepo.GetWithSpecByIdAsync(SpecJobProvider);
            string groupName = GetGroupName(JobSeekerId , JobProviderId);   
            string senderName = Role == "JobSeeker" ? JobSeeker.AppUser.UserName : JobProvider.AppUser.UserName;
            await Clients.Group(groupName).SendAsync("RecieveMessage", senderName, Context);
            var random = new Random();
            var Message = new Messages()
            {
                Id= random.Next(),
                Content = Context,
                JobProviderId = JobProvider.Id,
                JobSeekerId = JobSeeker.Id,
                JobProvider = JobProvider,
                JobSeeker = JobSeeker,
                UserName = Name
                
            };
          
            var Result =await _messageRepo.Add(Message);
            _logger.Log(LogLevel.Information,"warning") ;
            if (Result>0)
            {
               await _context.SaveChangesAsync();
            }
        }
        private static string GetGroupName (int JobSeekerId,int JobProviderId)
        {
            return $"Conversation {Math.Min(JobSeekerId,JobProviderId)}_{Math.Max(JobSeekerId,JobProviderId)}";
        }
        
    }
}
