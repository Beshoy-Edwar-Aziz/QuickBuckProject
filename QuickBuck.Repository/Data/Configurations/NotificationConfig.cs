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
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(N => new
            {
                N.Id,
                N.JobProviderId,
                N.JobSeekerId,
                N.JobPostId
            });
            builder.HasOne(n => n.JobProvider)
                    .WithMany(jp => jp.Notifications)
                    .HasForeignKey(n=>n.JobProviderId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
