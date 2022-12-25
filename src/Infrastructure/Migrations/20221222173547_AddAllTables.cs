using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class AddAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_AnswerType_AnswerTypeId",
                table: "Answer");

            migrationBuilder.DropTable(
                name: "SurveyQuestion");

            migrationBuilder.DropTable(
                name: "AnswerType");

            migrationBuilder.DropIndex(
                name: "IX_Answer_AnswerTypeId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "AnswerTypeId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "DescriptionAr",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "TitleAr",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ValueDescriptionAr",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ValueDescriptionEn",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ValueIconName",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ValueTitleAr",
                table: "AboutUs");

            migrationBuilder.RenameColumn(
                name: "ValueTitleEn",
                table: "AboutUs",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "AltImage",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Speciality",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Answer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blogs_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintNo = table.Column<int>(type: "int", nullable: false),
                    ComplaintMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Complaints_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Complaints_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceBefore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceAfter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offer_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offer_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OurValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OurValues_AboutUs_AboutUsId",
                        column: x => x.AboutUsId,
                        principalTable: "AboutUs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OverView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientRight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRight_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientRight_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientRight_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientSay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientSay_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientSay_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientSay_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Question_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Question_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Testiminie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testiminie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testiminie_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Testiminie_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Testiminie_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDetail_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfferDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferDetail_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OverViewDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    OverViewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverViewDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverViewDetail_OverView_OverViewId",
                        column: x => x.OverViewId,
                        principalTable: "OverView",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientRightDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientRightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRightDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRightDetail_PatientRight_PatientRightId",
                        column: x => x.PatientRightId,
                        principalTable: "PatientRight",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => new { x.QuestionId, x.AnswerId });
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestiminieDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestiminieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestiminieDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestiminieDetail_Testiminie_TestiminieId",
                        column: x => x.TestiminieId,
                        principalTable: "Testiminie",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "162ff3f1-24be-4909-9b76-15963abc52af");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5043), new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5043) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(4596), new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(4597) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5022), new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5023) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5001), new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(4989) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5091), new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5091) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5077), new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5077) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5106), new DateTime(2022, 12, 22, 19, 35, 46, 808, DateTimeKind.Local).AddTicks(5106) });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CreatedUserId",
                table: "Blogs",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_DeletedUserId",
                table: "Blogs",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_DepartmentId",
                table: "Blogs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_DoctorId",
                table: "Blogs",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_LastModifiedUserId",
                table: "Blogs",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_CreatedUserId",
                table: "Complaints",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_DeletedUserId",
                table: "Complaints",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_LastModifiedUserId",
                table: "Complaints",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CreatedUserId",
                table: "Event",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_DeletedUserId",
                table: "Event",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_LastModifiedUserId",
                table: "Event",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetail_EventId",
                table: "EventDetail",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_CreatedUserId",
                table: "Offer",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_DeletedUserId",
                table: "Offer",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_LastModifiedUserId",
                table: "Offer",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferDetail_OfferId",
                table: "OfferDetail",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OurValues_AboutUsId",
                table: "OurValues",
                column: "AboutUsId");

            migrationBuilder.CreateIndex(
                name: "IX_OverViewDetail_OverViewId",
                table: "OverViewDetail",
                column: "OverViewId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRight_CreatedUserId",
                table: "PatientRight",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRight_DeletedUserId",
                table: "PatientRight",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRight_LastModifiedUserId",
                table: "PatientRight",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRightDetail_PatientRightId",
                table: "PatientRightDetail",
                column: "PatientRightId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSay_CreatedUserId",
                table: "PatientSay",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSay_DeletedUserId",
                table: "PatientSay",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSay_LastModifiedUserId",
                table: "PatientSay",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CreatedUserId",
                table: "Question",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_DeletedUserId",
                table: "Question",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_LastModifiedUserId",
                table: "Question",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_AnswerId",
                table: "QuestionAnswer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Testiminie_CreatedUserId",
                table: "Testiminie",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Testiminie_DeletedUserId",
                table: "Testiminie",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Testiminie_LastModifiedUserId",
                table: "Testiminie",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestiminieDetail_TestiminieId",
                table: "TestiminieDetail",
                column: "TestiminieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "EventDetail");

            migrationBuilder.DropTable(
                name: "OfferDetail");

            migrationBuilder.DropTable(
                name: "OurValues");

            migrationBuilder.DropTable(
                name: "OverViewDetail");

            migrationBuilder.DropTable(
                name: "PatientRightDetail");

            migrationBuilder.DropTable(
                name: "PatientSay");

            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "TestiminieDetail");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "OverView");

            migrationBuilder.DropTable(
                name: "PatientRight");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Testiminie");

            migrationBuilder.DropColumn(
                name: "AltImage",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Answer");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "AboutUs",
                newName: "ValueTitleEn");

            migrationBuilder.AddColumn<int>(
                name: "AnswerTypeId",
                table: "Answer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAr",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleAr",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueDescriptionAr",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueDescriptionEn",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueIconName",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueTitleAr",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnswerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerType_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnswerType_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnswerType_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerTypeId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    TitleAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestion_AnswerType_AnswerTypeId",
                        column: x => x.AnswerTypeId,
                        principalTable: "AnswerType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveyQuestion_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveyQuestion_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveyQuestion_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "a75c163e-6a53-4376-b426-04192fcefcaa");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3692), new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3693) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3521), new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3522) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3676), new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3677) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3663), new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3659) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3724), new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3724) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3712), new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3713) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3738), new DateTime(2022, 12, 7, 17, 7, 48, 305, DateTimeKind.Local).AddTicks(3738) });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_AnswerTypeId",
                table: "Answer",
                column: "AnswerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerType_CreatedUserId",
                table: "AnswerType",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerType_DeletedUserId",
                table: "AnswerType",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerType_LastModifiedUserId",
                table: "AnswerType",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestion_AnswerTypeId",
                table: "SurveyQuestion",
                column: "AnswerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestion_CreatedUserId",
                table: "SurveyQuestion",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestion_DeletedUserId",
                table: "SurveyQuestion",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestion_LastModifiedUserId",
                table: "SurveyQuestion",
                column: "LastModifiedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_AnswerType_AnswerTypeId",
                table: "Answer",
                column: "AnswerTypeId",
                principalTable: "AnswerType",
                principalColumn: "Id");
        }
    }
}
