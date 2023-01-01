using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class UpdateQuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswer",
                table: "QuestionAnswer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswer",
                table: "QuestionAnswer",
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

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_QuestionId",
                table: "QuestionAnswer",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswer",
                table: "QuestionAnswer");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswer_QuestionId",
                table: "QuestionAnswer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswer",
                table: "QuestionAnswer",
                columns: new[] { "QuestionId", "AnswerId" });

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
        }
    }
}
