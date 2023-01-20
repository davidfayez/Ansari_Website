using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class SetImageNullableInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "4385b1fc-5df7-4e30-9113-ec9f8b901fde");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(7002), new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(7003) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(6772), new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(6772) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(6987), new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(6987) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(6970), new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(6959) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(7060), new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(7025), new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(7025) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(7076), new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(7077) });
        }
    }
}
