using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using QuickBuck.DTOs;
using QuickBuck.Errors;
using QuickBuck.Helpers;
using QuickBuck.Repository.Specifications;

namespace QuickBuck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IGenericRepository<JobProvider> _providerRepo;
        private readonly IGenericRepository<JobPost> _jobPostRepo;
        private readonly IMapper _mapper;

        public JobPostController(UserManager<AppUser> userManager,IGenericRepository<JobProvider> providerRepo, IGenericRepository<JobPost> jobPostRepo,IMapper mapper)
        {
            _userManager = userManager;
            _providerRepo = providerRepo;
            _jobPostRepo = jobPostRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<JobPostToReturnDTO>> GetAllJobPosts([FromQuery] JobPostParams Params)
        {
            var Spec = new JobPostWithIncludesAndCriteria();
            var JobPost = await _jobPostRepo.GetAllWithSpecAsync(Spec);
            var MappedJobPost = _mapper.Map<IReadOnlyList<JobPost>, IReadOnlyList<JobPostToReturnDTO>>(JobPost); 
            var Pagination = new Pagination<JobPostToReturnDTO>()
            {
                PageIndex = Params.PageIndex,
                PageSize = Params.pageSize,
                Data = MappedJobPost
            };
            return Ok(Pagination);
        }
        [HttpPost("{jobPosterId}")]
        public async Task<ActionResult<JobPost>> CreateJobPost(JobPostDTO jobPostDTO,[FromRoute] int jobPosterId)
        {
           var JobProvider= await _providerRepo.GetByIdWithAsync(jobPosterId);
            var JobPost = new JobPost()
            {
                Email = jobPostDTO.Email,
                Applicants = jobPostDTO.Applicants,
                Date = jobPostDTO.Date,
                jobProvider = JobProvider,
                Content = jobPostDTO.Content,
                Description = jobPostDTO.Description,
                SalaryRangeFrom = jobPostDTO.SalaryRangeFrom,
                SalaryRangeTo = jobPostDTO.SalaryRangeTo,
                Title = jobPostDTO.Title,
                RequiredSkills = jobPostDTO.RequiredSkills,
                Type = jobPostDTO.Type,
                Location = jobPostDTO.Location,
                InConsideration = jobPostDTO.InConsideration,
                Requirements = jobPostDTO.Requirements
            };
            var Result =await _jobPostRepo.Add(JobPost);
            if (Result==0)
            {
                return BadRequest(new ApiResponse(400,"Something Went Wrong"));
            }
            return Ok(JobPost);
        }
    }
}
