using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Repository.Specifications
{
    public class JobProviderWithIncludesAndCriteria:BaseSpecification<JobProvider>
    {
        public JobProviderWithIncludesAndCriteria()
        {
            ApplyOrderByDesc(P=>P.NoOfEmployees);
            ApplyPagination(0,5);
            Includes.Add(P=>P.AppUser);
            Includes.Add(P=>P.Messages);
            Includes.Add(P=>P.JobApplications);
            Includes.Add(P=>P.Transactions);
            Includes.Add(P=>P.Notifications);
        }
        public JobProviderWithIncludesAndCriteria(int? Id, string? UserName):base(P=>
        (Id==0)||(P.Id==Id)
        &&
        (string.IsNullOrEmpty(UserName))||(P.AppUser.UserName==UserName)
        )
        {
            Includes.Add(P => P.AppUser);
            Includes.Add(P => P.Messages);
            Includes.Add(P => P.JobApplications);
            Includes.Add(P => P.Transactions);
            Includes.Add(P => P.Notifications);
        }
    }
}
