﻿using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace withAuthentication.Models
{
    public partial class PThreeDbContext : IdentityDbContext
    {
        public PThreeDbContext()
        {
        }

        public PThreeDbContext(DbContextOptions<PThreeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<DeveloperReview> DeveloperReviews { get; set; }
        public virtual DbSet<PotentialBuyer> PotentialBuyers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Realtor> Realtors { get; set; }
        public virtual DbSet<RealtorReview> RealtorReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-IOE3SSUK\\SQLEXPRESS;Database=PThreeDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.ToTable("Developer");

                entity.Property(e => e.DeveloperId).HasColumnName("developerID");

                entity.Property(e => e.AvgStarRating)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("avgStarRating");

                entity.Property(e => e.DeveloperName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("developerName");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Logo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("logo");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber")
                    .IsFixedLength(true);

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("website");
            });

            modelBuilder.Entity<DeveloperReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__Develope__2ECD6E2437022F5B");

                entity.ToTable("DeveloperReview");

                entity.Property(e => e.ReviewId).HasColumnName("reviewID");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.DeveloperId).HasColumnName("developerID");

                entity.Property(e => e.PotentialBuyerId).HasColumnName("potentialBuyerID");

                entity.Property(e => e.StarRating).HasColumnName("starRating");

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.DeveloperReviews)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK_rDeveloperID");

                entity.HasOne(d => d.PotentialBuyer)
                    .WithMany(p => p.DeveloperReviews)
                    .HasForeignKey(d => d.PotentialBuyerId)
                    .HasConstraintName("FK_potentialBuyerID");
            });

            modelBuilder.Entity<PotentialBuyer>(entity =>
            {
                entity.ToTable("PotentialBuyer");

                entity.Property(e => e.PotentialBuyerId).HasColumnName("potentialBuyerID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId).HasColumnName("projectID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.DeveloperId).HasColumnName("developerID");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("postalCode")
                    .IsFixedLength(true);

                entity.Property(e => e.ProjectImage)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("projectImage");

                entity.Property(e => e.ProjectStatus)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("projectStatus");

                entity.Property(e => e.StreetName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("streetName");

                entity.Property(e => e.StreetNum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("streetNum");

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK_developerID");
            });

            modelBuilder.Entity<Realtor>(entity =>
            {
                entity.ToTable("Realtor");

                entity.Property(e => e.RealtorId).HasColumnName("realtorID");

                entity.Property(e => e.AvgStarRating)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("avgStarRating");

                entity.Property(e => e.BioText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("bioText");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("companyName");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("facebook");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Instagram)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("instagram");

                entity.Property(e => e.Languages)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("languages");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.LinkedIn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("linkedIn");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber")
                    .IsFixedLength(true);

                entity.Property(e => e.ProfilePic)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("profilePic");

                entity.Property(e => e.Twitter)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("twitter");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("website");

                entity.Property(e => e.Youtube)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("youtube");
            });

            modelBuilder.Entity<RealtorReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__RealtorR__2ECD6E242A9243B3");

                entity.ToTable("RealtorReview");

                entity.Property(e => e.ReviewId).HasColumnName("reviewID");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.PotentialBuyerId).HasColumnName("potentialBuyerID");

                entity.Property(e => e.RealtorId).HasColumnName("realtorID");

                entity.Property(e => e.StarRating).HasColumnName("starRating");

                entity.HasOne(d => d.PotentialBuyer)
                    .WithMany(p => p.RealtorReviews)
                    .HasForeignKey(d => d.PotentialBuyerId)
                    .HasConstraintName("FK_rPotentialBuyerID");

                entity.HasOne(d => d.Realtor)
                    .WithMany(p => p.RealtorReviews)
                    .HasForeignKey(d => d.RealtorId)
                    .HasConstraintName("FK_realtorID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
