using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickBuck.Core.Models;

namespace QuickBuck.Repository.Data.Configurations
{
    public class MessagesConfig : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.HasKey(M => new
            {
                M.Id,
                M.JobProviderId,
                M.JobSeekerId
            });  
        }
    }
}
