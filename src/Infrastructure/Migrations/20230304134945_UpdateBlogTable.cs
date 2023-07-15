using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class UpdateBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_CreatedUserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_DeletedUserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_DoctorId1",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_LastModifiedUserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Department_DepartmentId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CreatedUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_DeletedUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_DoctorId1",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_LastModifiedUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "IsSystem",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "ReviewsNo",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TitleEn",
                table: "Blogs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TitleAr",
                table: "Blogs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUs_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactUs_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactUs_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "69ab68af-a9db-413b-9a0f-d8e8cb7ef2f6");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6855), new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6855) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6659), new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6840), new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6824), new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6894), new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6878), new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6878) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6905), new DateTime(2023, 3, 4, 15, 49, 44, 271, DateTimeKind.Local).AddTicks(6906) });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_DoctorId",
                table: "Blogs",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_CreatedUserId",
                table: "ContactUs",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_DeletedUserId",
                table: "ContactUs",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_LastModifiedUserId",
                table: "ContactUs",
                column: "LastModifiedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_DoctorId",
                table: "Blogs",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Department_DepartmentId",
                table: "Blogs",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_DoctorId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Department_DepartmentId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_DoctorId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ReviewsNo",
                table: "Offer");

            migrationBuilder.AlterColumn<string>(
                name: "TitleEn",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "TitleAr",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorId1",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsSystem",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "e8e3807d-9a01-4540-8e44-29cf30436668");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6244), new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6245) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6062), new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6062) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6231), new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6232) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6216), new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6282), new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6282) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6269), new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6269) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6292), new DateTime(2023, 2, 25, 15, 45, 0, 782, DateTimeKind.Local).AddTicks(6293) });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CreatedUserId",
                table: "Blogs",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_DeletedUserId",
                table: "Blogs",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_DoctorId1",
                table: "Blogs",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_LastModifiedUserId",
                table: "Blogs",
                column: "LastModifiedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_CreatedUserId",
                table: "Blogs",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_DeletedUserId",
                table: "Blogs",
                column: "DeletedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_DoctorId1",
                table: "Blogs",
                column: "DoctorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_LastModifiedUserId",
                table: "Blogs",
                column: "LastModifiedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Department_DepartmentId",
                table: "Blogs",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
