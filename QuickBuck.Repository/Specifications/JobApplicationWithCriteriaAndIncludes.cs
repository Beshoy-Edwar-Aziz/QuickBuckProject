using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Repository.Specifications
{
    public class JobApplicationWithCriteriaAndIncludes:BaseSpecification<JobApplication>
    {
        public JobApplicationWithCriteriaAndIncludes(int? id=0,int? JobPostId=0) : base(
            JA=>
            (id==0)||(JA.Id==id)
            &&
            (JobPostId==0)||(JA.JobPostId==JobPostId)
            )
        {
            Includes.Add(JA=>JA.JobSeeker);
        }
        
    }
}
