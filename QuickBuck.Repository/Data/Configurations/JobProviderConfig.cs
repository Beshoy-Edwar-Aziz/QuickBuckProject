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
    public class JobProviderConfig : IEntityTypeConfiguration<JobProvider>
    {
        public void Configure(EntityTypeBuilder<JobProvider> builder)
        {
            builder.HasOne(p=>p.Wallet).WithOne(w=>w.JobProvider).HasForeignKey<JobProvider>(p=>p.WalletId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
