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
        public JobPostWithIncludesAndCriteria(JobPostParams Params):base(jb=>
        (string.IsNullOrEmpty(Params.JobName)||(jb.Title.Contains(Params.JobName))))
        {
            ApplyPagination(Params.pageSize * (Params.PageIndex - 1), Params.pageSize);
            Includes.Add(JP => JP.jobProvider);
            Includes.Add(JP => JP.JobApplications);
            Includes.Add(JP=>JP.RequiredSkills);
            Includes.Add(JP=>JP.Requirements);
            if (!string.IsNullOrEmpty(Params.Sort))
            {
                switch (Params.Sort)
                {
                    case "OrderByDesc":
                        ApplyOrderByDesc(P => P.Date);
                        break;
                    case "OrderByAsc":
                        ApplyOrderBy(P => P.Date);
                        break;
                }
            }
        }
        
        public JobPostWithIncludesAndCriteria(int jobProvider,string CompanyName):base(P=>
        P.jobProvider.Id==jobProvider)
        {
            ApplyOrderByDesc(p => p.Date);
            ApplyPagination(0,4);
            Includes.Add(JP => JP.jobProvider);
            Includes.Add(JP => JP.JobApplications);
            Includes.Add(JP => JP.RequiredSkills);
            Includes.Add(JP => JP.Requirements);
        }

    }
}
