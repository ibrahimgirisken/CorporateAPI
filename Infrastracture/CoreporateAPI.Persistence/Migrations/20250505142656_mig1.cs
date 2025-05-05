using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreporateAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesktopImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableteImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesktopVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ParentId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId1",
                        column: x => x.ParentId1,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Datasheets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datasheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EndpointMenus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndpointMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ModuleIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WhiteLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlackLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GooglePlus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleAnalytics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleRecaptcha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleTagManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleSiteVerification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMaps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    BrandId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId1",
                        column: x => x.BrandId1,
                        principalSchema: "dbo",
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Endpoints",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HttpType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndpointMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endpoints_EndpointMenus_EndpointMenuId",
                        column: x => x.EndpointMenuId,
                        principalSchema: "dbo",
                        principalTable: "EndpointMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BannerTranslations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannerTranslations_Banners_BannerId",
                        column: x => x.BannerId,
                        principalSchema: "dbo",
                        principalTable: "Banners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BannerTranslations_Languages_LangId",
                        column: x => x.LangId,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTranslations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brief = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Languages_LangId",
                        column: x => x.LangId,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DatasheetTranslations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatasheetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatasheetTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatasheetTranslations_Datasheets_DatasheetId",
                        column: x => x.DatasheetId,
                        principalSchema: "dbo",
                        principalTable: "Datasheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DatasheetTranslations_Languages_LangId",
                        column: x => x.LangId,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeTranslations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeTranslations_Homes_HomeId",
                        column: x => x.HomeId,
                        principalSchema: "dbo",
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeTranslations_Languages_LangId",
                        column: x => x.LangId,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleTranslations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleTranslations_Languages_LangId",
                        column: x => x.LangId,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModuleTranslations_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "dbo",
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageTranslations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brief = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageTranslations_Languages_LangId",
                        column: x => x.LangId,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageTranslations_Pages_PageId",
                        column: x => x.PageId,
                        principalSchema: "dbo",
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SettingTranslations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingTranslations_Languages_LangId",
                        column: x => x.LangId,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SettingTranslations_Settings_SettingId",
                        column: x => x.SettingId,
                        principalSchema: "dbo",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brief = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Languages_LangId",
                        column: x => x.LangId,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleEndpoint",
                schema: "dbo",
                columns: table => new
                {
                    EndpointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleEndpoint", x => new { x.EndpointsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_AppRoleEndpoint_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRoleEndpoint_Endpoints_EndpointsId",
                        column: x => x.EndpointsId,
                        principalSchema: "dbo",
                        principalTable: "Endpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Languages",
                columns: new[] { "Id", "CreatedDate", "Image", "IsDeleted", "LangCode", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tr.png", false, "tr", "Türkçe", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "en.png", false, "en", "English", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "de.png", false, "de", "Deutsch", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Settings",
                columns: new[] { "Id", "Address", "BlackLogo", "CreatedDate", "Email", "Facebook", "GoogleAnalytics", "GoogleMaps", "GooglePlus", "GoogleRecaptcha", "GoogleSiteVerification", "GoogleTagManager", "Instagram", "IsDeleted", "LinkedIn", "Status", "Telephone", "Twitter", "UpdatedDate", "WhiteLogo", "Youtube" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Address", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, false, null, true, "123456789", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SettingTranslations",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "LangId", "MetaDescription", "SettingId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("11111111-1111-1111-1111-111111111111"), "Türkçe Description", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Türkçe Title", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("22222222-2222-2222-2222-222222222222"), "English Description", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "English Title", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("33333333-3333-3333-3333-333333333333"), "Deutsch Description", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Deutsch Title", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleEndpoint_RolesId",
                schema: "dbo",
                table: "AppRoleEndpoint",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BannerTranslations_BannerId_LangId",
                schema: "dbo",
                table: "BannerTranslations",
                columns: new[] { "BannerId", "LangId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BannerTranslations_LangId",
                schema: "dbo",
                table: "BannerTranslations",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId1",
                schema: "dbo",
                table: "Categories",
                column: "ParentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId_LangId",
                schema: "dbo",
                table: "CategoryTranslations",
                columns: new[] { "CategoryId", "LangId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_LangId",
                schema: "dbo",
                table: "CategoryTranslations",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_DatasheetTranslations_DatasheetId_LangId",
                schema: "dbo",
                table: "DatasheetTranslations",
                columns: new[] { "DatasheetId", "LangId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatasheetTranslations_LangId",
                schema: "dbo",
                table: "DatasheetTranslations",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_EndpointMenuId",
                schema: "dbo",
                table: "Endpoints",
                column: "EndpointMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_ContentType",
                schema: "dbo",
                table: "Homes",
                column: "ContentType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeTranslations_HomeId_LangId",
                schema: "dbo",
                table: "HomeTranslations",
                columns: new[] { "HomeId", "LangId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeTranslations_LangId",
                schema: "dbo",
                table: "HomeTranslations",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LangCode",
                schema: "dbo",
                table: "Languages",
                column: "LangCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTranslations_LangId",
                schema: "dbo",
                table: "ModuleTranslations",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTranslations_ModuleId_LangId",
                schema: "dbo",
                table: "ModuleTranslations",
                columns: new[] { "ModuleId", "LangId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PageTranslations_LangId",
                schema: "dbo",
                table: "PageTranslations",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_PageTranslations_PageId_LangId",
                schema: "dbo",
                table: "PageTranslations",
                columns: new[] { "PageId", "LangId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId1",
                schema: "dbo",
                table: "Products",
                column: "BrandId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId1",
                schema: "dbo",
                table: "Products",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_LangId",
                schema: "dbo",
                table: "ProductTranslations",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductId_LangId",
                schema: "dbo",
                table: "ProductTranslations",
                columns: new[] { "ProductId", "LangId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SettingTranslations_LangId",
                schema: "dbo",
                table: "SettingTranslations",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingTranslations_SettingId_LangId",
                schema: "dbo",
                table: "SettingTranslations",
                columns: new[] { "SettingId", "LangId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleEndpoint",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BannerTranslations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CategoryTranslations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DatasheetTranslations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HomeTranslations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ModuleTranslations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PageTranslations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductTranslations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SettingTranslations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Endpoints",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Banners",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Datasheets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Homes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Modules",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EndpointMenus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");
        }
    }
}
