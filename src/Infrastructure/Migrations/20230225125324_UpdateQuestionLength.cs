using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class UpdateQuestionLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TitleEn",
                table: "Question",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TitleAr",
                table: "Question",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "b4f549de-0428-431c-991a-95cc2a90fe3f");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4759), new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4760) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4565), new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4565) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4741), new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4742) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4717) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4808), new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4808) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4792), new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4793) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4824), new DateTime(2023, 2, 25, 14, 53, 23, 638, DateTimeKind.Local).AddTicks(4825) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TitleEn",
                table: "Question",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "TitleAr",
                table: "Question",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "60816d57-969a-4d83-a387-383607d9c1fb");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6446), new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6447) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6236), new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6237) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6431), new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6431) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6416), new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6408) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6520), new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6510), new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6535), new DateTime(2023, 2, 16, 21, 30, 4, 654, DateTimeKind.Local).AddTicks(6536) });
        }
    }
}
