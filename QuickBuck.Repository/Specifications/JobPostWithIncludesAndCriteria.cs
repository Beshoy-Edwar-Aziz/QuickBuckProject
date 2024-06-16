using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuickBuck.Repository.Specifications
{
    public class JobPostWithIncludesAndCriteria:BaseSpecification<JobPost>
    {
        public JobPostWithIncludesAndCriteria(int id):base(P=>
        (id==0)||(P.Id==id)) 
        {
            Includes.Add(JP=>JP.jobProvider);
            Includes.Add(JP => JP.JobApplications);
            Includes.Add(JP => JP.RequiredSkills);
            Includes.Add(JP => JP.Requirements);
        }
        public JobPostWithIncludesAndCriteria(JobPostParams Params)
        {
            ApplyPagination(Params.pageSize * (Params.PageIndex - 1), Params.pageSize);
            Includes.Add(JP => JP.jobProvider);
            Includes.Add(JP => JP.JobApplications);
            Includes.Add(JP=>JP.RequiredSkills);
            Includes.Add(JP=>JP.Requirements);
        }
        
    }
}
