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
    
    public class JobApplicationController : ApiBaseController
    {
        private readonly IGenericRepository<JobApplication> _jobAppRepo;
        private readonly IGenericRepository<JobProvider> _providerRepo;
        private readonly IGenericRepository<JobSeeker> _seekerRepo;
        private readonly IGenericRepository<JobPost> _postRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<JobApplication> appRepo;

        public JobApplicationController(IGenericRepository<JobApplication> jobAppRepo,IGenericRepository<JobProvider> providerRepo, IGenericRepository<JobSeeker> seekerRepo, IGenericRepository<JobPost> postRepo,IMapper mapper,IGenericRepository<JobApplication> appRepo)
        {
            _jobAppRepo = jobAppRepo;
            _providerRepo = providerRepo;
            _seekerRepo = seekerRepo;
            _postRepo = postRepo;
            _mapper = mapper;
            this.appRepo = appRepo;
        }
        [HttpPost]
        public async Task<ActionResult<JobApplication>> CreateJobApplication(JobApplicationDTO Model, [FromQuery] int JobProviderId,[FromQuery]int JobPostId, [FromQuery]int JobSeekerId)
        {
            var Spec = new JobProviderWithIncludesAndCriteria(JobProviderId,null);
            var SpecJobSeeker = new JobSeekerSpecWithIncludeAndCriteria(JobSeekerId);
            var Params = new JobPostParams()
            {
                Id = JobPostId,
            };
            var SpecJobPost = new JobPostWithIncludesAndCriteria(Params);
            var JobProvider = await _providerRepo.GetWithSpecByIdAsync(Spec);
            var JobSeeker = await _seekerRepo.GetWithSpecByIdAsync(SpecJobSeeker);
            var JobPost = await _postRepo.GetWithSpecByIdAsync(SpecJobPost);
            if (Model is not null&&JobProviderId!=0&&JobSeekerId!=0&&JobPostId!=0)
            {
                var DecodeBase64 = Convert.FromBase64String(Model.CV);
                var FileName =DocumentSettings.UploadFile(DecodeBase64,"document","Files");
                var DecodeCoverLetterBase64 = Convert.FromBase64String(Model.CoverLetter);
                var Cover = DocumentSettings.UploadFile(DecodeCoverLetterBase64,"document","Files");
                var JobApplication = new JobApplication()
                {
                    CV = FileName,
                    JobPostId= JobPostId,
                    JobProviderId= JobProviderId,
                    JobSeekerId= JobSeekerId,
                    JobProvider = JobProvider,
                    JobSeeker = JobSeeker,
                    JobPost = JobPost,
                    ApplicationDate=Model.ApplicationDate,
                    CoverLetter=Cover,
                    Status=Model.Status,
                };
                var jobs = await appRepo.GetAllWithAsync();
                bool state = true;
                int Result = 0;
                foreach (var j in jobs)
                {
                    if (j.JobSeekerId == JobSeekerId)
                    {
                        state = false;
                        if (state==false)
                        {
                            break;
                        }
                    }
                
                }
                if (state)
                {
                     Result = await _jobAppRepo.Add(JobApplication);
                }
                else
                {
                    return BadRequest(new ApiResponse(400,"JobSeeker Created A JobApplication Before"));
                }
                var ReturnData = new JobApplicationToReturnDTO()
                {
                    ApplicationDate = Model.ApplicationDate,
                    CoverLetter= Cover,
                    CV = FileName,
                    JobPostId = JobPostId,
                    JobProviderId= JobProviderId,
                    JobSeekerId= JobSeekerId,
                    Status = Model.Status
                };
                return Ok(Result>0?ReturnData:BadRequest(new ApiResponse(400,"Failed To Save JobApplication")));
            }
            else
            {
                return BadRequest(new ApiResponse(400,"Data wasn't provided to Api Properly"));
            }
        }
        [HttpGet]
        public async Task<ActionResult<JobApplicationToReturnDTO>> GetJobApplication([FromQuery]int Id)
        {
            
        }
        
    }
}
