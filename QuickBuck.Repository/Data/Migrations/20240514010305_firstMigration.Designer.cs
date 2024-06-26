﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickBuck.Repository.Data;

#nullable disable

namespace QuickBuck.Repository.Data.Migrations
{
    [DbContext(typeof(QuickBuckContext))]
    [Migration("20240514010305_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuickBuck.Core.Models.Bookmark", b =>
                {
                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<int>("JobPostId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobSeekerId", "JobPostId");

                    b.HasIndex("JobPostId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.JobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobPostId")
                        .HasColumnType("int");

                    b.Property<int>("JobProviderId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobPostId");

                    b.HasIndex("JobProviderId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.JobPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Applicants")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InConsideration")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SalaryRangeFrom")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalaryRangeTo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Viewed")
                        .HasColumnType("int");

                    b.Property<int>("jobProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("jobProviderId");

                    b.ToTable("JobPosts");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.JobProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanySize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfEmployees")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobProviders");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.JobSeeker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("College")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentYear")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("JobSeekers");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Messages", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("JobProviderId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "JobProviderId", "JobSeekerId");

                    b.HasIndex("JobProviderId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("JobProviderId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<int>("JobPostId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "JobProviderId", "JobSeekerId", "JobPostId");

                    b.HasIndex("JobPostId");

                    b.HasIndex("JobProviderId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.RequiredSkills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("JobPostId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobPostId");

                    b.ToTable("RequiredSkills");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Requirements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("JobPostId")
                        .HasColumnType("int");

                    b.Property<string>("ReqName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqPriority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobPostId");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Skills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Transactions", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.Property<int>("JobProviderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "WalletId", "JobProviderId");

                    b.HasIndex("JobProviderId");

                    b.HasIndex("WalletId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Bookmark", b =>
                {
                    b.HasOne("QuickBuck.Core.Models.JobPost", "JobPost")
                        .WithMany("Bookmarks")
                        .HasForeignKey("JobPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickBuck.Core.Models.JobSeeker", "JobSeeker")
                        .WithMany("Bookmarks")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPost");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.JobApplication", b =>
                {
                    b.HasOne("QuickBuck.Core.Models.JobPost", "JobPost")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickBuck.Core.Models.JobProvider", "JobProvider")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobProviderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QuickBuck.Core.Models.JobSeeker", "JobSeeker")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPost");

                    b.Navigation("JobProvider");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.JobPost", b =>
                {
                    b.HasOne("QuickBuck.Core.Models.JobProvider", "jobProvider")
                        .WithMany()
                        .HasForeignKey("jobProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("jobProvider");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.JobSeeker", b =>
                {
                    b.HasOne("QuickBuck.Core.Models.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Messages", b =>
                {
                    b.HasOne("QuickBuck.Core.Models.JobProvider", "JobProvider")
                        .WithMany("Messages")
                        .HasForeignKey("JobProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickBuck.Core.Models.JobSeeker", "JobSeeker")
                        .WithMany("Messages")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobProvider");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Notification", b =>
                {
                    b.HasOne("QuickBuck.Core.Models.JobPost", "JobPost")
                        .WithMany()
                        .HasForeignKey("JobPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickBuck.Core.Models.JobProvider", "JobProvider")
                        .WithMany("Notifications")
                        .HasForeignKey("JobProviderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QuickBuck.Core.Models.JobSeeker", "JobSeeker")
                        .WithMany("Notifications")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPost");

                    b.Navigation("JobProvider");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.RequiredSkills", b =>
                {
                    b.HasOne("QuickBuck.Core.Models.JobPost", null)
                        .WithMany("RequiredSkills")
                        .HasForeignKey("JobPostId");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Requirements", b =>
                {
                    b.HasOne("QuickBuck.Core.Models.JobPost", null)
                        .WithMany("Requirements")
                        .HasForeignKey("JobPostId");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Skills", b =>
                {
                    b.HasOne("QuickBuck.Core.Models.JobSeeker", null)
                        .WithMany("Skills")
                        .HasForeignKey("JobSeekerId");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Transactions", b =>
                {
                    b.HasOne("QuickBuck.Core.Models.JobProvider", "JobProvider")
                        .WithMany("Transactions")
                        .HasForeignKey("JobProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickBuck.Core.Models.Wallet", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobProvider");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.JobPost", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("JobApplications");

                    b.Navigation("RequiredSkills");

                    b.Navigation("Requirements");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.JobProvider", b =>
                {
                    b.Navigation("JobApplications");

                    b.Navigation("Messages");

                    b.Navigation("Notifications");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.JobSeeker", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("JobApplications");

                    b.Navigation("Messages");

                    b.Navigation("Notifications");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("QuickBuck.Core.Models.Wallet", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
