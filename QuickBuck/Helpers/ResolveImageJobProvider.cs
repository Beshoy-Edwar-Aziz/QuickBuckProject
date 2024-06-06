using AutoMapper;
using QuickBuck.Core.Models;
using QuickBuck.DTOs;

namespace QuickBuck.Helpers
{
    public class ResolveImageJobProvider : IValueResolver<JobProvider, JobProviderToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ResolveImageJobProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(JobProvider source, JobProviderToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Logo))
            {
                return $"{_configuration["ApiBaseUrl"]}/images/photos/{source.Logo}";
            }
            return string.Empty;
        }
    }
}
