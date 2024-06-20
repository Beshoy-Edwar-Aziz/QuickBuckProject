using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using QuickBuck.DTOs;
using QuickBuck.Errors;
using QuickBuck.Repository.Specifications;

namespace QuickBuck.Controllers
{
   
    public class JobProviderController : ApiBaseController
    {
        private readonly IGenericRepository<JobProvider> _providerRepo;
        private readonly IMapper _mapper;

        public JobProviderController(IGenericRepository<JobProvider> providerRepo, IMapper mapper)
        {
            _providerRepo = providerRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<JobProviderToReturnDTO>> GetAllJobProviders()
        {
            var Spec = new JobProviderWithIncludesAndCriteria();
            var Providers = await _providerRepo.GetAllWithSpecAsync(Spec);
            var MappedProviders = _mapper.Map<IReadOnlyList<JobProvider>,IReadOnlyList<JobProviderToReturnDTO>>(Providers); 
            return Ok(MappedProviders);
        }
        [HttpGet("GetUser")]
        public async Task<ActionResult<JobProviderToReturnDTO>> GetJobProviderById([FromQuery]int? Id, [FromQuery]string? UserName)
        {
            var Spec = new JobProviderWithIncludesAndCriteria(Id,UserName);
            var Provider = await _providerRepo.GetWithSpecByIdAsync(Spec);
            if (Provider is null)
            {
                return NotFound(new ApiResponse(404,"JobProvider Not Found"));
            }
            
            var MappedProviders = _mapper.Map<JobProvider, JobProviderToReturnDTO>(Provider);
            
            return Ok(MappedProviders);
        }
        [HttpPut("UpdatePremium")]
        public async Task<ActionResult<JobProviderToReturnDTO>> UpdateProviderPremium([FromQuery] int JobProviderId, [FromQuery] bool status)
        {
            var Spec = new JobProviderWithIncludesAndCriteria(JobProviderId,null);
            var Provider = await _providerRepo.GetWithSpecByIdAsync(Spec);
            if (Provider is not null) 
            {
                Provider.Premium= status;
                await _providerRepo.Update(Provider);
            }
            else
            {
                return BadRequest(new ApiResponse(400,"ProviderId is invalid"));
            }
            var Mapped = _mapper.Map<JobProvider,JobProviderToReturnDTO>(Provider);
            return Ok(Mapped);
        }
    }
}
