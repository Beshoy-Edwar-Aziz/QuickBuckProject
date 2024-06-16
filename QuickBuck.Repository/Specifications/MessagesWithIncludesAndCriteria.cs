using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Repository.Specifications
{
    public class MessagesWithIncludesAndCriteria:BaseSpecification<Messages>
    {
        public MessagesWithIncludesAndCriteria(MessagesParams Params):base(P=>
        P.JobProviderId==Params.JobProviderId&&P.JobSeekerId==Params.JobSeekerId)
        {
           
            Includes.Add(P=>P.JobProvider);
            Includes.Add(P=>P.JobSeeker);
            Includes.Add(P => P.JobSeeker.AppUser);
            ApplyOrderByDesc(P => P.DateTime);
            ApplyPagination(0, 5);

        }
        public MessagesWithIncludesAndCriteria(int? JobProviderId, int? JobSeekerId):base(P=>
        (JobProviderId == 0) || (P.JobProviderId == JobProviderId)
        &&
        (JobSeekerId == 0) || (P.JobSeekerId == JobSeekerId))
        {
            ApplyOrderByDesc(P => P.DateTime);
            DistinctBy(P => P.JobProviderId);
            Includes.Add(P => P.JobProvider);
            Includes.Add(P => P.JobSeeker);
            Includes.Add(P=>P.JobSeeker.AppUser);
        }
        public MessagesWithIncludesAndCriteria(int id):base(P=>
        (id == 0) || (P.Id==id))
        {
            Includes.Add(P => P.JobProvider);
            Includes.Add(P => P.JobSeeker);
            Includes.Add(P => P.JobSeeker.AppUser);
        }
    }
}
