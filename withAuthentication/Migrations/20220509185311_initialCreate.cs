using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace withAuthentication.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    developerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    developerName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    phoneNumber = table.Column<string>(type: "TEXT", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: false),
                    website = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    logo = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    avgStarRating = table.Column<decimal>(type: "decimal(2, 1)", nullable: true),
                    subscription_expiration = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.developerID);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    languageID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    languageCode = table.Column<string>(type: "TEXT", unicode: false, maxLength: 3, nullable: true),
                    languageName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.languageID);
                });

            migrationBuilder.CreateTable(
                name: "PotentialBuyer",
                columns: table => new
                {
                    potentialBuyerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 15, nullable: true),
                    lastName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 15, nullable: true),
                    phoneNumber = table.Column<string>(type: "TEXT", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 25, nullable: false),
                    profilePic = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialBuyer", x => x.potentialBuyerID);
                });

            migrationBuilder.CreateTable(
                name: "Realtor",
                columns: table => new
                {
                    realtorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 15, nullable: true),
                    lastName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 25, nullable: false),
                    companyName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 25, nullable: true),
                    phoneNumber = table.Column<string>(type: "TEXT", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    profilePic = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    bioText = table.Column<string>(type: "TEXT", unicode: false, maxLength: 255, nullable: true),
                    avgStarRating = table.Column<decimal>(type: "decimal(2, 1)", nullable: true),
                    website = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    linkedIn = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    twitter = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    youtube = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    facebook = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    instagram = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    subscription_expiration = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realtor", x => x.realtorID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    projectID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    developerID = table.Column<int>(type: "INTEGER", nullable: true),
                    streetNum = table.Column<string>(type: "TEXT", unicode: false, maxLength: 10, nullable: true),
                    streetName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 25, nullable: true),
                    city = table.Column<string>(type: "TEXT", unicode: false, maxLength: 15, nullable: true),
                    postalCode = table.Column<string>(type: "TEXT", unicode: false, fixedLength: true, maxLength: 6, nullable: true),
                    projectStatus = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: true),
                    projectImage = table.Column<string>(type: "TEXT", unicode: false, maxLength: 250, nullable: true),
                    projectName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 500, nullable: false),
                    projectLink = table.Column<string>(type: "TEXT", unicode: false, maxLength: 2500, nullable: true),
                    projectDescription = table.Column<string>(type: "TEXT", unicode: false, maxLength: 5000, nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    expectedCompletion = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.projectID);
                    table.ForeignKey(
                        name: "FK_developerID",
                        column: x => x.developerID,
                        principalTable: "Developer",
                        principalColumn: "developerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperReview",
                columns: table => new
                {
                    reviewID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    developerID = table.Column<int>(type: "INTEGER", nullable: true),
                    potentialBuyerID = table.Column<int>(type: "INTEGER", nullable: true),
                    starRating = table.Column<int>(type: "INTEGER", nullable: false),
                    comment = table.Column<string>(type: "TEXT", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Develope__2ECD6E24D9E4EA39", x => x.reviewID);
                    table.ForeignKey(
                        name: "FK_potentialBuyerID",
                        column: x => x.potentialBuyerID,
                        principalTable: "PotentialBuyer",
                        principalColumn: "potentialBuyerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rDeveloperID",
                        column: x => x.developerID,
                        principalTable: "Developer",
                        principalColumn: "developerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealtorLanguage",
                columns: table => new
                {
                    realtorLanguageID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    realtorID = table.Column<int>(type: "INTEGER", nullable: true),
                    languageID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtorLanguage", x => x.realtorLanguageID);
                    table.ForeignKey(
                        name: "FK_LanguageID",
                        column: x => x.languageID,
                        principalTable: "Language",
                        principalColumn: "languageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lRealtorID",
                        column: x => x.realtorID,
                        principalTable: "Realtor",
                        principalColumn: "realtorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealtorReview",
                columns: table => new
                {
                    reviewID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    realtorID = table.Column<int>(type: "INTEGER", nullable: true),
                    potentialBuyerID = table.Column<int>(type: "INTEGER", nullable: true),
                    starRating = table.Column<int>(type: "INTEGER", nullable: false),
                    comment = table.Column<string>(type: "TEXT", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RealtorR__2ECD6E24B012921C", x => x.reviewID);
                    table.ForeignKey(
                        name: "FK_realtorID",
                        column: x => x.realtorID,
                        principalTable: "Realtor",
                        principalColumn: "realtorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rPotentialBuyerID",
                        column: x => x.potentialBuyerID,
                        principalTable: "PotentialBuyer",
                        principalColumn: "potentialBuyerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperReview_developerID",
                table: "DeveloperReview",
                column: "developerID");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperReview_potentialBuyerID",
                table: "DeveloperReview",
                column: "potentialBuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_developerID",
                table: "Project",
                column: "developerID");

            migrationBuilder.CreateIndex(
                name: "IX_RealtorLanguage_languageID",
                table: "RealtorLanguage",
                column: "languageID");

            migrationBuilder.CreateIndex(
                name: "IX_RealtorLanguage_realtorID",
                table: "RealtorLanguage",
                column: "realtorID");

            migrationBuilder.CreateIndex(
                name: "IX_RealtorReview_potentialBuyerID",
                table: "RealtorReview",
                column: "potentialBuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_RealtorReview_realtorID",
                table: "RealtorReview",
                column: "realtorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeveloperReview");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "RealtorLanguage");

            migrationBuilder.DropTable(
                name: "RealtorReview");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Realtor");

            migrationBuilder.DropTable(
                name: "PotentialBuyer");
        }
    }
}
