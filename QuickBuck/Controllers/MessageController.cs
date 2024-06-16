using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using QuickBuck.DTOs;
using QuickBuck.Helpers;
using QuickBuck.Repository.Specifications;

namespace QuickBuck.Controllers
{
   
    public class MessageController : ApiBaseController
    {
        private readonly IGenericRepository<JobProvider> providerRepo;
        private readonly IGenericRepository<JobSeeker> seekerRepo;
        private readonly IMapper _mapper;

        public MessageController(IGenericRepository<Messages> messagesRepo,IMapper mapper)
        {
            _MessagesRepo = messagesRepo;
            this.providerRepo = providerRepo;
            this.seekerRepo = seekerRepo;
            _mapper = mapper;
        }

        public IGenericRepository<Messages> _MessagesRepo { get; }

        [HttpGet]
        public async Task<ActionResult<MessageToReturnDTO>> GetAllMessages([FromQuery] MessagesParams Params)
        
        {
            var Spec = new MessagesWithIncludesAndCriteria(Params);
            var Messages = await _MessagesRepo.GetAllWithSpecAsync(Spec);
            var MappedMsg = _mapper.Map<IReadOnlyList<Messages>, IReadOnlyList<MessageToReturnDTO>>(Messages);
            return Ok(MappedMsg);
        }
        [HttpGet("GetPrevious")]
        public async Task<ActionResult<MessageToReturnDTO>> GetMessagesByJobSeekerId([FromQuery] int? JobSeekerId, [FromQuery] int? JobProviderId)
        {
            var Spec = new MessagesWithIncludesAndCriteria(JobProviderId,JobSeekerId);
            var Messages = await _MessagesRepo.GetAllWithSpecAsync(Spec);
            IEnumerable<Messages> filtered;
            if (JobSeekerId>0) {
                filtered = Messages.DistinctBy(m => m.JobProviderId);
            }
            else
            {
                filtered = Messages.DistinctBy(m=>m.JobSeekerId);
            }
            var MappedMsg = _mapper.Map<IEnumerable<Messages>, IEnumerable<MessageToReturnDTO>>(filtered);
            return Ok(MappedMsg);
        }
        [HttpGet("GetMsg")]
        public async Task<ActionResult<MessageToReturnDTO>> GetMessageById([FromQuery] int id)
        {
            var Spec = new MessagesWithIncludesAndCriteria(id);
            var Message = await _MessagesRepo.GetWithSpecByIdAsync(Spec);
            var MappedMsg = _mapper.Map<Messages, MessageToReturnDTO>(Message);
            return Ok(MappedMsg);
        }
    }
}
