using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Repository.Specifications
{
    public class JobSeekerSpecWithIncludeAndCriteria:BaseSpecification<JobSeeker>
    {
        public JobSeekerSpecWithIncludeAndCriteria()
        {
            Includes.Add(J => J.AppUser);
            Includes.Add(J=>J.AppUser.Address);
            Includes.Add(J=>J.Wallet);
            Includes.Add(J=>J.JobApplications);
        }
        public JobSeekerSpecWithIncludeAndCriteria(int id):base(J=>J.Id==id)
        {
            Includes.Add(J => J.AppUser);
            Includes.Add(J => J.AppUser.Address);
            Includes.Add(J => J.Wallet);
            Includes.Add(J => J.JobApplications);
        }
        public JobSeekerSpecWithIncludeAndCriteria(string UserName):base(J=>J.AppUser.UserName==UserName)
        {
            Includes.Add(J => J.AppUser);
            Includes.Add(J => J.AppUser.Address);
            Includes.Add(J => J.Wallet);
            Includes.Add(J => J.JobApplications);
        }
    }
}
