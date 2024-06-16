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
            var SpecJobPost = new JobPostWithIncludesAndCriteria(JobPostId);
            var JobProvider = await _providerRepo.GetWithSpecByIdAsync(Spec);
            var JobSeeker = await _seekerRepo.GetWithSpecByIdAsync(SpecJobSeeker);
            var JobPost = await _postRepo.GetWithSpecByIdAsync(SpecJobPost);
            if (Model is not null&&JobProviderId!=0&&JobSeekerId!=0&&JobPostId!=0)
            {
                var decodeSplit = Model.CV.Split(',')[1];
                var DecodeBase64 = Convert.FromBase64String(decodeSplit);
                var FileName =DocumentSettings.UploadFile(DecodeBase64,"document","Files");
                var decodeSplitCover = Model.CoverLetter.Split(',')[1];
                var DecodeCoverLetterBase64 = Convert.FromBase64String(decodeSplitCover);
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
                int JobAppId = 0;
                foreach (var j in jobs)
                {
                    if (j.JobSeekerId == JobSeekerId&&j.JobPostId==JobPostId)
                    {
                        state = false;
                        JobAppId = j.Id;
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
                    var spec = new JobApplicationWithCriteriaAndIncludes(JobAppId);
                    var job =await _jobAppRepo.GetWithSpecByIdAsync(spec);
                    DocumentSettings.DeleteFile(job.CV,"Files","document");
                    DocumentSettings.DeleteFile(job.CoverLetter, "Files", "document");
                    job.JobSeeker = JobSeeker;
                    job.JobPost = JobPost;
                    job.ApplicationDate = Model.ApplicationDate;
                    job.Status= Model.Status;
                    job.CV = FileName;
                    job.CoverLetter = Cover;
                    job.JobPostId = JobPostId;
                    job.JobSeekerId=JobSeekerId;
                    job.JobProviderId = JobProviderId;
                    
                    await _jobAppRepo.Update(job);
                    var mapped=_mapper.Map<JobApplication, JobApplicationToReturnDTO>(job);

                    return Ok(mapped);
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
        public async Task<ActionResult<JobApplicationToReturnDTO>> GetJobApplicationById([FromQuery]int Id)
        {
            var Spec = new JobApplicationWithCriteriaAndIncludes(Id);
            var Result =await _jobAppRepo.GetWithSpecByIdAsync(Spec);
            if (Result is not null)
            {
                var MappedJobApp = _mapper.Map<JobApplication, JobApplicationToReturnDTO>(Result);
                return Ok(MappedJobApp);
            }
            return BadRequest(new ApiResponse(400));
        }
        [HttpPut]
        public async Task<ActionResult<JobPost>> AttachJobApplicationWithJobPost([FromQuery] int JobPostId)
        {
            
            var Spec = new JobPostWithIncludesAndCriteria(JobPostId);
            var JobPost=await _postRepo.GetWithSpecByIdAsync(Spec);
            var SpecJobApp = new JobApplicationWithCriteriaAndIncludes(null,JobPostId);
            var JobApplications = await _jobAppRepo.GetAllWithSpecAsync(SpecJobApp);
            JobPost.JobApplications = (ICollection<JobApplication>)JobApplications;
            JobPost.Applicants = JobApplications.Count();
            await _postRepo.Update(JobPost);
            
            var MappedJob=_mapper.Map<JobPost,JobPostToReturnDTO>(JobPost);
            var MappedApps = _mapper.Map<IReadOnlyList<JobApplication>, IReadOnlyList<JobApplicationToReturnDTO>>(JobApplications);
            MappedJob.JobApplications = (ICollection<JobApplicationToReturnDTO>)MappedApps;
            return Ok(MappedJob);
        }
        
    }
}
