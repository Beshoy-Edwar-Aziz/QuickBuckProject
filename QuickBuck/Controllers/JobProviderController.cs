using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using QuickBuck.Errors;
using QuickBuck.Repository.Specifications;

namespace QuickBuck.Controllers
{
   
    public class JobProviderController : ApiBaseController
    {
        private readonly IGenericRepository<JobProvider> _providerRepo;

        public JobProviderController(IGenericRepository<JobProvider> providerRepo)
        {
            _providerRepo = providerRepo;
        }
        [HttpGet]
        public async Task<ActionResult<JobProvider>> GetAllJobProviders()
        {
            var Spec = new JobProviderWithIncludesAndCriteria();
            var Providers = await _providerRepo.GetAllWithSpecAsync(Spec);
            return Ok(Providers);
        }
        [HttpGet("GetUser")]
        public async Task<ActionResult<JobProvider>> GetJobProviderById([FromQuery]int? Id, [FromQuery]string? UserName)
        {
            var Spec = new JobProviderWithIncludesAndCriteria(Id,UserName);
            var Provider = await _providerRepo.GetWithSpecByIdAsync(Spec);
            if (Provider is null)
            {
                return NotFound(new ApiResponse(404,"JobProvider Not Found"));
            }
            return Ok(Provider);
        }
    }
}
