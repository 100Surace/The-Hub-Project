using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hub.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
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
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Zip = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserStatus = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Coupon",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.CouponId);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Ids = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Ids);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
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
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
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
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashPayment",
                columns: table => new
                {
                    CashPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RefFromOrderHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashPaidDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashPayment", x => x.CashPaymentId);
                    table.ForeignKey(
                        name: "FK_CashPayment_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeader",
                columns: table => new
                {
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeader", x => x.OrderHeaderId);
                    table.ForeignKey(
                        name: "FK_OrderHeader_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    Ids = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserDetailsCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_UserDetail_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPayment",
                columns: table => new
                {
                    UserPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPayment", x => x.UserPaymentId);
                    table.ForeignKey(
                        name: "FK_UserPayment_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleCategory",
                columns: table => new
                {
                    Ids = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ModuleCategoryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleCategory", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_ModuleCategory_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgFee",
                columns: table => new
                {
                    OrgFeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    OrgFeeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OrgFeePrice = table.Column<double>(type: "float", nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: false),
                    OrgSaleFeePrice = table.Column<double>(type: "float", nullable: false),
                    OrgFeeDetail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MaxCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgFee", x => x.OrgFeeId);
                    table.ForeignKey(
                        name: "FK_OrgFee_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Org",
                columns: table => new
                {
                    Ids = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleCategoryId = table.Column<int>(type: "int", nullable: false),
                    serviceType = table.Column<int>(type: "int", nullable: false),
                    organizationType = table.Column<int>(type: "int", nullable: false),
                    OrgName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecondEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LongDesc = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BannerImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrgImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    OrgCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Org", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_Org_ModuleCategory_ModuleCategoryId",
                        column: x => x.ModuleCategoryId,
                        principalTable: "ModuleCategory",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adv",
                columns: table => new
                {
                    AdvId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrgFeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AdvBannerImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AdvFee = table.Column<double>(type: "float", nullable: false),
                    ADVStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adv", x => x.AdvId);
                    table.ForeignKey(
                        name: "FK_Adv_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adv_OrgFee_OrgFeeId",
                        column: x => x.OrgFeeId,
                        principalTable: "OrgFee",
                        principalColumn: "OrgFeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Annual",
                columns: table => new
                {
                    AnnualId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgFeeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnnualCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annual", x => x.AnnualId);
                    table.ForeignKey(
                        name: "FK_Annual_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Annual_OrgFee_OrgFeeId",
                        column: x => x.OrgFeeId,
                        principalTable: "OrgFee",
                        principalColumn: "OrgFeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<int>(type: "int", nullable: false),
                    Commentor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDetail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HubUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_HubUserId",
                        column: x => x.HubUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Org_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Org",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRego",
                columns: table => new
                {
                    EventRegoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    EventStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventGuest = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EventCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EventCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EventZip = table.Column<int>(type: "int", nullable: false),
                    EventImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EventFee = table.Column<double>(type: "float", nullable: false),
                    EventAward = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EventRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxPerson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRego", x => x.EventRegoId);
                    table.ForeignKey(
                        name: "FK_EventRego_Org_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Org",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<int>(type: "int", nullable: false),
                    FacilityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_Facility_Org_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Org",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fee",
                columns: table => new
                {
                    FeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<int>(type: "int", nullable: false),
                    FeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FeePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fee", x => x.FeeId);
                    table.ForeignKey(
                        name: "FK_Fee_Org_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Org",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsRegister",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<int>(type: "int", nullable: false),
                    NewsTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NewsDesc = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NewsLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsRegister", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK_NewsRegister_Org_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Org",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<int>(type: "int", nullable: false),
                    RatingValue = table.Column<double>(type: "float", nullable: false),
                    Rater = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RateddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HubUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Rating_AspNetUsers_HubUserId",
                        column: x => x.HubUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Org_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Org",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvOrderDetail",
                columns: table => new
                {
                    AdvOrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    AdvId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvOrderDetail", x => x.AdvOrderDetailId);
                    table.ForeignKey(
                        name: "FK_AdvOrderDetail_Adv_AdvId",
                        column: x => x.AdvId,
                        principalTable: "Adv",
                        principalColumn: "AdvId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvOrderDetail_OrderHeader_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeader",
                        principalColumn: "OrderHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnualOrderDetail",
                columns: table => new
                {
                    AnnualOrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    AnnualId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualOrderDetail", x => x.AnnualOrderDetailId);
                    table.ForeignKey(
                        name: "FK_AnnualOrderDetail_Annual_AnnualId",
                        column: x => x.AnnualId,
                        principalTable: "Annual",
                        principalColumn: "AnnualId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnualOrderDetail_OrderHeader_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeader",
                        principalColumn: "OrderHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AnnualId = table.Column<int>(type: "int", nullable: true),
                    AdvId = table.Column<int>(type: "int", nullable: true),
                    CouponId = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Adv_AdvId",
                        column: x => x.AdvId,
                        principalTable: "Adv",
                        principalColumn: "AdvId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Annual_AnnualId",
                        column: x => x.AnnualId,
                        principalTable: "Annual",
                        principalColumn: "AnnualId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "CouponId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentReply",
                columns: table => new
                {
                    CommentReplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    Commentor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplyCommentDetail = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HubUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReply", x => x.CommentReplyId);
                    table.ForeignKey(
                        name: "FK_CommentReply_AspNetUsers_HubUserId",
                        column: x => x.HubUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentReply_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventApplyForm",
                columns: table => new
                {
                    EventApplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EventRegoId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumOfPerson = table.Column<int>(type: "int", nullable: false),
                    TotalFee = table.Column<double>(type: "float", nullable: false),
                    EventApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventApplyForm", x => x.EventApplyId);
                    table.ForeignKey(
                        name: "FK_EventApplyForm_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventApplyForm_EventRego_EventRegoId",
                        column: x => x.EventRegoId,
                        principalTable: "EventRego",
                        principalColumn: "EventRegoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchList",
                columns: table => new
                {
                    WatchListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventRegoId = table.Column<int>(type: "int", nullable: true),
                    NewsId = table.Column<int>(type: "int", nullable: true),
                    NewsRegisterNewsId = table.Column<int>(type: "int", nullable: true),
                    AdvId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchList", x => x.WatchListId);
                    table.ForeignKey(
                        name: "FK_WatchList_Adv_AdvId",
                        column: x => x.AdvId,
                        principalTable: "Adv",
                        principalColumn: "AdvId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WatchList_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchList_EventRego_EventRegoId",
                        column: x => x.EventRegoId,
                        principalTable: "EventRego",
                        principalColumn: "EventRegoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WatchList_NewsRegister_NewsRegisterNewsId",
                        column: x => x.NewsRegisterNewsId,
                        principalTable: "NewsRegister",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adv_Id",
                table: "Adv",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Adv_OrgFeeId",
                table: "Adv",
                column: "OrgFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvOrderDetail_AdvId",
                table: "AdvOrderDetail",
                column: "AdvId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvOrderDetail_OrderHeaderId",
                table: "AdvOrderDetail",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Annual_Id",
                table: "Annual",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Annual_OrgFeeId",
                table: "Annual",
                column: "OrgFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualOrderDetail_AnnualId",
                table: "AnnualOrderDetail",
                column: "AnnualId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualOrderDetail_OrderHeaderId",
                table: "AnnualOrderDetail",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CashPayment_Id",
                table: "CashPayment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_HubUserId",
                table: "Comment",
                column: "HubUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_OrgId",
                table: "Comment",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReply_CommentId",
                table: "CommentReply",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReply_HubUserId",
                table: "CommentReply",
                column: "HubUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventApplyForm_EventRegoId",
                table: "EventApplyForm",
                column: "EventRegoId");

            migrationBuilder.CreateIndex(
                name: "IX_EventApplyForm_Id",
                table: "EventApplyForm",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EventRego_OrgId",
                table: "EventRego",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_OrgId",
                table: "Facility",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Fee_OrgId",
                table: "Fee",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleCategory_ModuleId",
                table: "ModuleCategory",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsRegister_OrgId",
                table: "NewsRegister",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_Id",
                table: "OrderHeader",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Org_ModuleCategoryId",
                table: "Org",
                column: "ModuleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgFee_ModuleId",
                table: "OrgFee",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_HubUserId",
                table: "Rating",
                column: "HubUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_OrgId",
                table: "Rating",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_AdvId",
                table: "ShoppingCart",
                column: "AdvId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_AnnualId",
                table: "ShoppingCart",
                column: "AnnualId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CouponId",
                table: "ShoppingCart",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_Id",
                table: "ShoppingCart",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_Id",
                table: "UserDetail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayment_Id",
                table: "UserPayment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WatchList_AdvId",
                table: "WatchList",
                column: "AdvId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchList_EventRegoId",
                table: "WatchList",
                column: "EventRegoId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchList_Id",
                table: "WatchList",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WatchList_NewsRegisterNewsId",
                table: "WatchList",
                column: "NewsRegisterNewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvOrderDetail");

            migrationBuilder.DropTable(
                name: "AnnualOrderDetail");

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
                name: "CashPayment");

            migrationBuilder.DropTable(
                name: "CommentReply");

            migrationBuilder.DropTable(
                name: "EventApplyForm");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Fee");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "UserDetail");

            migrationBuilder.DropTable(
                name: "UserPayment");

            migrationBuilder.DropTable(
                name: "WatchList");

            migrationBuilder.DropTable(
                name: "OrderHeader");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Annual");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Adv");

            migrationBuilder.DropTable(
                name: "EventRego");

            migrationBuilder.DropTable(
                name: "NewsRegister");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrgFee");

            migrationBuilder.DropTable(
                name: "Org");

            migrationBuilder.DropTable(
                name: "ModuleCategory");

            migrationBuilder.DropTable(
                name: "Module");
        }
    }
}
