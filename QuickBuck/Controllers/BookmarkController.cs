using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using QuickBuck.DTOs;
using QuickBuck.Errors;
using QuickBuck.Repository.Specifications;

namespace QuickBuck.Controllers
{
    public class BookmarkController : ApiBaseController
    {
        private readonly IGenericRepository<Bookmark> _bookMarkRepo;
        private readonly IGenericRepository<JobPost> _postRepo;
        private readonly IGenericRepository<JobSeeker> _seekerRepo;

        public BookmarkController(IGenericRepository<Bookmark> bookMarkRepo, IGenericRepository<JobPost> postRepo,IGenericRepository<JobSeeker> seekerRepo)
        {
            _bookMarkRepo = bookMarkRepo;
            _postRepo = postRepo;
            _seekerRepo = seekerRepo;
        }
        [HttpPost]
        public async Task<ActionResult<Bookmark>> CreateBookMark(BookMarkDTO Model, [FromQuery] int JobSeekerId, [FromQuery] int JobPostId)
        {
            var SpecMark = new BookMarkWithIncludesAndCriteria(JobSeekerId,JobPostId);
            var Mark = await _bookMarkRepo.GetWithSpecByIdAsync(SpecMark);
            if (Mark is not null)
            {
                return BadRequest(new ApiResponse(400,"JobPost Has Already Been Bookmarked Before"));
            }
            var Post=await _postRepo.GetByIdWithAsync(JobPostId);
            var Seeker = await _seekerRepo.GetByIdWithAsync(JobSeekerId);
            var Bookmark = new Bookmark()
            {
                JobPostId = JobPostId,
                JobSeekerId = JobSeekerId,    
                Title = Model.Title,
                JobPost=Post,
                JobSeeker=Seeker
            };
            var Result =await _bookMarkRepo.Add(Bookmark);
            if (Result>0)
            {
                return Ok(Bookmark);
            }
            return BadRequest(new ApiResponse(400,"Something Went Wrong"));
        }
        [HttpGet]
        public async Task<ActionResult<Bookmark>> GetBookMarkByJobSeekerId([FromQuery] int JobSeekerId)
        {
            var Spec = new BookMarkWithIncludesAndCriteria(JobSeekerId);
            var BookMark = await _bookMarkRepo.GetAllWithSpecAsync(Spec);
            return Ok(BookMark);
        }
    }
}
