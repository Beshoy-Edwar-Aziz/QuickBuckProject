﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("MyPolicy")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {
        private readonly IGenericRepository<JobSeeker> _jobSeekerRepo;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper _mapper;

        public JobSeekerController(IGenericRepository<JobSeeker> _jobSeekerRepo, RoleManager<IdentityRole> roleManager,IMapper mapper)
        {
            this._jobSeekerRepo = _jobSeekerRepo;
            this.roleManager = roleManager;
            _mapper = mapper;
        }
        [HttpGet]
        //[Authorize(Roles ="JobSeeker")]
        //public async Task<ActionResult<JobSeekerToReturnDTO>> GetAllJobSeekers()
        //{
        //    var Spec = new JobSeekerSpecWithIncludeAndCriteria();
        //    var Seekers = await _jobSeekerRepo.GetAllWithSpecAsync(Spec);
        //    var MappedSeekers = _mapper.Map<IReadOnlyList<JobSeeker>, IReadOnlyList<JobSeekerToReturnDTO>>(Seekers);
        //    return Ok(MappedSeekers);
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<JobSeekerToReturnDTO>> GetJobSeekerById(int id)
        {
            var Spec = new JobSeekerSpecWithIncludeAndCriteria(id);
            var Seeker = await _jobSeekerRepo.GetWithSpecByIdAsync(Spec);
            var MappedSeeker = _mapper.Map<JobSeeker, JobSeekerToReturnDTO>(Seeker);
            return Ok(MappedSeeker);
        }
        [HttpGet("GetUser/{UserName}")]
        public async Task<ActionResult<JobSeekerToReturnDTO>> GetJobSeekerByUserName(string UserName)
        {
            var Spec = new JobSeekerSpecWithIncludeAndCriteria(UserName);
            var Seeker = await _jobSeekerRepo.GetWithSpecByIdAsync(Spec);
            var MappedSeeker = _mapper.Map<JobSeeker, JobSeekerToReturnDTO>(Seeker);
            return Ok(MappedSeeker);
        }
        [HttpGet("SearchCandidates")]
        public async Task<ActionResult<JobSeekerToReturnDTO>> SearchCandidates([FromQuery] JobSeekerParams Params)
        {
            var Spec = new JobSeekerSpecWithIncludeAndCriteria(Params);
            var Seekers = await _jobSeekerRepo.GetAllWithSpecAsync(Spec);
            if (Seekers is not null)
            {
                var Mapped = _mapper.Map<IReadOnlyList<JobSeeker>, IReadOnlyList<JobSeekerToReturnDTO>>(Seekers);
                return Ok(Mapped);
            }
            return BadRequest(new ApiResponse(400,"Seeker is invalid"));
        }
        [HttpPut]
        public async Task<ActionResult<JobSeekerToReturnDTO>> UpdateJobSeekerData (JobSeekerDTO Model)
        {
            var Spec = new JobSeekerSpecWithIncludeAndCriteria(Model.Id);
            var JobSeeker = await _jobSeekerRepo.GetWithSpecByIdAsync (Spec);
            var x = Model.Photo.Split(',')[1];
            var Photo = Convert.FromBase64String(x);
            var result = DocumentSettings.UploadFile(Photo, "image", "photos");
            JobSeeker.Status = Model.Status;
            JobSeeker.CurrentYear = Model.CurrentYear;
            JobSeeker.Photo = result;
            JobSeeker.Skills = Model.Skills;
            JobSeeker.University = Model.University;
            JobSeeker.College = Model.College;
            await _jobSeekerRepo.Update(JobSeeker);
            return Ok(Model);
        }
        [HttpPut("UpdatePremium")]
        public async Task<ActionResult<JobSeekerToReturnDTO>> updatejobseekerstatus([FromQuery]int JobSeekerId,[FromQuery] bool status)
        {
            var Spec = new JobSeekerSpecWithIncludeAndCriteria(JobSeekerId);
            var Seeker = await _jobSeekerRepo.GetWithSpecByIdAsync(Spec);
            if (Seeker is not null)
            {
                Seeker.Premium = status;
                await _jobSeekerRepo.Update(Seeker);
            }
            else
            {
                return BadRequest(new ApiResponse(400,"JobSeekerId is invalid"));
            }
            var Mapped = _mapper.Map<JobSeeker, JobSeekerToReturnDTO>(Seeker);
            return Ok(Mapped);
        }
    }
}
