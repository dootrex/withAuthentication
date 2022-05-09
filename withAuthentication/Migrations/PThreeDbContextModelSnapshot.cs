﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using withAuthentication.Models;

namespace withAuthentication.Migrations
{
    [DbContext(typeof(PThreeDbContext))]
    partial class PThreeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("withAuthentication.Models.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("developerID");

                    b.Property<decimal?>("AvgStarRating")
                        .HasColumnType("decimal(2, 1)")
                        .HasColumnName("avgStarRating");

                    b.Property<string>("DeveloperName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("developerName");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("Logo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("logo");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("phoneNumber")
                        .IsFixedLength(true);

                    b.Property<DateTime?>("SubscriptionExpiration")
                        .HasColumnType("date")
                        .HasColumnName("subscription_expiration");

                    b.Property<string>("Website")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("website");

                    b.HasKey("DeveloperId");

                    b.ToTable("Developer");
                });

            modelBuilder.Entity("withAuthentication.Models.DeveloperReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("reviewID");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("comment");

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("developerID");

                    b.Property<int?>("PotentialBuyerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("potentialBuyerID");

                    b.Property<int>("StarRating")
                        .HasColumnType("INTEGER")
                        .HasColumnName("starRating");

                    b.HasKey("ReviewId")
                        .HasName("PK__Develope__2ECD6E24D9E4EA39");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("PotentialBuyerId");

                    b.ToTable("DeveloperReview");
                });

            modelBuilder.Entity("withAuthentication.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("languageID");

                    b.Property<string>("LanguageCode")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("languageCode");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("languageName");

                    b.HasKey("LanguageId");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("withAuthentication.Models.PotentialBuyer", b =>
                {
                    b.Property<int>("PotentialBuyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("potentialBuyerID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("lastName");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("phoneNumber")
                        .IsFixedLength(true);

                    b.Property<string>("ProfilePic")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("profilePic");

                    b.HasKey("PotentialBuyerId");

                    b.ToTable("PotentialBuyer");
                });

            modelBuilder.Entity("withAuthentication.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("projectID");

                    b.Property<string>("City")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("city");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("developerID");

                    b.Property<DateTime?>("ExpectedCompletion")
                        .HasColumnType("date")
                        .HasColumnName("expectedCompletion");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("postalCode")
                        .IsFixedLength(true);

                    b.Property<string>("ProjectDescription")
                        .HasMaxLength(5000)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("projectDescription");

                    b.Property<string>("ProjectImage")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("projectImage");

                    b.Property<string>("ProjectLink")
                        .HasMaxLength(2500)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("projectLink");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("projectName");

                    b.Property<string>("ProjectStatus")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("projectStatus");

                    b.Property<string>("StreetName")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("streetName");

                    b.Property<string>("StreetNum")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("streetNum");

                    b.HasKey("ProjectId");

                    b.HasIndex("DeveloperId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("withAuthentication.Models.Realtor", b =>
                {
                    b.Property<int>("RealtorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("realtorID");

                    b.Property<decimal?>("AvgStarRating")
                        .HasColumnType("decimal(2, 1)")
                        .HasColumnName("avgStarRating");

                    b.Property<string>("BioText")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("bioText");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("companyName");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("Facebook")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("facebook");

                    b.Property<string>("FirstName")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("firstName");

                    b.Property<string>("Instagram")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("instagram");

                    b.Property<string>("LastName")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("lastName");

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("linkedIn");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("phoneNumber")
                        .IsFixedLength(true);

                    b.Property<string>("ProfilePic")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("profilePic");

                    b.Property<DateTime?>("SubscriptionExpiration")
                        .HasColumnType("date")
                        .HasColumnName("subscription_expiration");

                    b.Property<string>("Twitter")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("twitter");

                    b.Property<string>("Website")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("website");

                    b.Property<string>("Youtube")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("youtube");

                    b.HasKey("RealtorId");

                    b.ToTable("Realtor");
                });

            modelBuilder.Entity("withAuthentication.Models.RealtorLanguage", b =>
                {
                    b.Property<int>("RealtorLanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("realtorLanguageID");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("languageID");

                    b.Property<int?>("RealtorId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("realtorID");

                    b.HasKey("RealtorLanguageId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("RealtorId");

                    b.ToTable("RealtorLanguage");
                });

            modelBuilder.Entity("withAuthentication.Models.RealtorReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("reviewID");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("comment");

                    b.Property<int?>("PotentialBuyerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("potentialBuyerID");

                    b.Property<int?>("RealtorId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("realtorID");

                    b.Property<int>("StarRating")
                        .HasColumnType("INTEGER")
                        .HasColumnName("starRating");

                    b.HasKey("ReviewId")
                        .HasName("PK__RealtorR__2ECD6E24B012921C");

                    b.HasIndex("PotentialBuyerId");

                    b.HasIndex("RealtorId");

                    b.ToTable("RealtorReview");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("withAuthentication.Models.DeveloperReview", b =>
                {
                    b.HasOne("withAuthentication.Models.Developer", "Developer")
                        .WithMany("DeveloperReviews")
                        .HasForeignKey("DeveloperId")
                        .HasConstraintName("FK_rDeveloperID");

                    b.HasOne("withAuthentication.Models.PotentialBuyer", "PotentialBuyer")
                        .WithMany("DeveloperReviews")
                        .HasForeignKey("PotentialBuyerId")
                        .HasConstraintName("FK_potentialBuyerID");

                    b.Navigation("Developer");

                    b.Navigation("PotentialBuyer");
                });

            modelBuilder.Entity("withAuthentication.Models.Project", b =>
                {
                    b.HasOne("withAuthentication.Models.Developer", "Developer")
                        .WithMany("Projects")
                        .HasForeignKey("DeveloperId")
                        .HasConstraintName("FK_developerID");

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("withAuthentication.Models.RealtorLanguage", b =>
                {
                    b.HasOne("withAuthentication.Models.Language", "Language")
                        .WithMany("RealtorLanguages")
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("FK_LanguageID");

                    b.HasOne("withAuthentication.Models.Realtor", "Realtor")
                        .WithMany("RealtorLanguages")
                        .HasForeignKey("RealtorId")
                        .HasConstraintName("FK_lRealtorID");

                    b.Navigation("Language");

                    b.Navigation("Realtor");
                });

            modelBuilder.Entity("withAuthentication.Models.RealtorReview", b =>
                {
                    b.HasOne("withAuthentication.Models.PotentialBuyer", "PotentialBuyer")
                        .WithMany("RealtorReviews")
                        .HasForeignKey("PotentialBuyerId")
                        .HasConstraintName("FK_rPotentialBuyerID");

                    b.HasOne("withAuthentication.Models.Realtor", "Realtor")
                        .WithMany("RealtorReviews")
                        .HasForeignKey("RealtorId")
                        .HasConstraintName("FK_realtorID");

                    b.Navigation("PotentialBuyer");

                    b.Navigation("Realtor");
                });

            modelBuilder.Entity("withAuthentication.Models.Developer", b =>
                {
                    b.Navigation("DeveloperReviews");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("withAuthentication.Models.Language", b =>
                {
                    b.Navigation("RealtorLanguages");
                });

            modelBuilder.Entity("withAuthentication.Models.PotentialBuyer", b =>
                {
                    b.Navigation("DeveloperReviews");

                    b.Navigation("RealtorReviews");
                });

            modelBuilder.Entity("withAuthentication.Models.Realtor", b =>
                {
                    b.Navigation("RealtorLanguages");

                    b.Navigation("RealtorReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
