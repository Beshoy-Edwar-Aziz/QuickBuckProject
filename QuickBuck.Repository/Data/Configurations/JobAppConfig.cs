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
    public class JobAppConfig : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.HasOne(app => app.JobProvider)
                    .WithMany(jp => jp.JobApplications)
                    .HasForeignKey(app=>app.JobProviderId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
