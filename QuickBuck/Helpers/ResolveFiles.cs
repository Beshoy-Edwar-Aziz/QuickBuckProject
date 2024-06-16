using AutoMapper;
using QuickBuck.Core.Models;
using QuickBuck.DTOs;

namespace QuickBuck.Helpers
{
    public class ResolveFiles : IValueResolver<JobApplication, JobApplicationToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ResolveFiles(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(JobApplication source, JobApplicationToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.CV))
            {
                return $"{_configuration["ApiBaseUrl"]}Files/{source.CV}";
            }
            return string.Empty;
        }
    }
}
