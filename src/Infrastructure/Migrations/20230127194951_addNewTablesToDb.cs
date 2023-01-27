using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class addNewTablesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Doctor_DoctorId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_DoctorId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "DoctorId1",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "8cf2f6dd-d4e1-4e17-859a-d86075c3c87b");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(4924), new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(4925) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(4536), new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(4537) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(4893), new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(4893) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(4864), new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(4854) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(5002), new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(4978), new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(4978) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(5034), new DateTime(2023, 1, 27, 21, 49, 50, 325, DateTimeKind.Local).AddTicks(5035) });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_DoctorId1",
                table: "Blogs",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_DoctorId1",
                table: "Blogs",
                column: "DoctorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_DoctorId1",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_DoctorId1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "05724639-08a6-456e-a1f8-2db42f8505c9");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7304), new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7108), new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7109) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7289), new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7289) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7270), new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7265) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7344), new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7345) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7333), new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7334) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7361), new DateTime(2023, 1, 13, 14, 59, 33, 495, DateTimeKind.Local).AddTicks(7361) });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_DoctorId",
                table: "Blogs",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Doctor_DoctorId",
                table: "Blogs",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
