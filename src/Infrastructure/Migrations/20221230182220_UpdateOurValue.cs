using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class UpdateOurValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OurValues_AboutUs_AboutUsId",
                table: "OurValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OurValues",
                table: "OurValues");

            migrationBuilder.RenameTable(
                name: "OurValues",
                newName: "OurValue");

            migrationBuilder.RenameIndex(
                name: "IX_OurValues_AboutUsId",
                table: "OurValue",
                newName: "IX_OurValue_AboutUsId");

            migrationBuilder.AlterColumn<string>(
                name: "TitleEn",
                table: "OurValue",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TitleAr",
                table: "OurValue",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AboutUsId",
                table: "OurValue",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OurValue",
                table: "OurValue",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "91199298-dc0d-4c9b-acd2-660485a29bf7");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3330), new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3068), new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3069) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3304), new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3305) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3279), new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3265) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3368), new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3369) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3356), new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3357) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3381), new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3382) });

            migrationBuilder.AddForeignKey(
                name: "FK_OurValue_AboutUs_AboutUsId",
                table: "OurValue",
                column: "AboutUsId",
                principalTable: "AboutUs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OurValue_AboutUs_AboutUsId",
                table: "OurValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OurValue",
                table: "OurValue");

            migrationBuilder.RenameTable(
                name: "OurValue",
                newName: "OurValues");

            migrationBuilder.RenameIndex(
                name: "IX_OurValue_AboutUsId",
                table: "OurValues",
                newName: "IX_OurValues_AboutUsId");

            migrationBuilder.AlterColumn<string>(
                name: "TitleEn",
                table: "OurValues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TitleAr",
                table: "OurValues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "AboutUsId",
                table: "OurValues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OurValues",
                table: "OurValues",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "03fd1b95-af27-4b69-be0a-c5167bcae8bf");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1151), new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1151) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(928), new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(929) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1101), new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1101) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1082), new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1077) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1195), new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1195) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1184), new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1184) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1208), new DateTime(2022, 12, 28, 22, 47, 20, 859, DateTimeKind.Local).AddTicks(1208) });

            migrationBuilder.AddForeignKey(
                name: "FK_OurValues_AboutUs_AboutUsId",
                table: "OurValues",
                column: "AboutUsId",
                principalTable: "AboutUs",
                principalColumn: "Id");
        }
    }
}
