using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Repository.Specifications
{
    public class BookMarkWithIncludesAndCriteria:BaseSpecification<Bookmark>
    {
        public BookMarkWithIncludesAndCriteria(int jobSeekerId) : base(b=>b.JobSeekerId==jobSeekerId)
        {
            Includes.Add(b=>b.JobSeeker);
            Includes.Add(b=>b.JobPost);
        }
        public BookMarkWithIncludesAndCriteria(int JobSeekerId,int JobPostId):base(b=>b.JobSeekerId==JobSeekerId&&b.JobPostId==JobPostId)
        {
            Includes.Add(b => b.JobSeeker);
            Includes.Add(b => b.JobPost);
        }
    }
}
