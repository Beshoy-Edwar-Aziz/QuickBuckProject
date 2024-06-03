using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickBuck.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Repository.Data
{
    public class QuickBuckContext:IdentityDbContext<AppUser>
    {
        public QuickBuckContext(DbContextOptions<QuickBuckContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobProvider> JobProviders { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}
