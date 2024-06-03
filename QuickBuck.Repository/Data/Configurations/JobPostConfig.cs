using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuck.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Repository.Data.Configurations
{
    public class JobPostConfig : IEntityTypeConfiguration<JobPost>
    {
        public void Configure(EntityTypeBuilder<JobPost> builder)
        {
            builder.Property(J => J.SalaryRangeFrom).HasColumnType("decimal(18,2)");
            builder.Property(J => J.SalaryRangeTo).HasColumnType("decimal(18,2)");
        }
    }
}
