using AutoMapper;
using AutoMapper.Execution;
using QuickBuck.Core.Models;
using QuickBuck.DTOs;

namespace QuickBuck.Helpers
{
    public class ResolveImage : IValueResolver<JobSeeker, JobSeekerToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ResolveImage(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(JobSeeker source, JobSeekerToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Photo))
            {
                return $"{_configuration["ApiBaseUrl"]}{source.Photo}";
            }
            return string.Empty;
        }
    }
}
