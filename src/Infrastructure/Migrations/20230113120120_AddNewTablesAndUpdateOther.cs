using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class AddNewTablesAndUpdateOther : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserId",
                table: "OverView",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "OverView",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "OverView",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OverView",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OverView",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystem",
                table: "OverView",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "OverView",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "OverView",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
                columns: new[] { "CreationDate", "FinancialYearEnd", "FinancialYearStart", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(6970), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 13, 14, 1, 19, 510, DateTimeKind.Local).AddTicks(6959) });

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

            migrationBuilder.CreateIndex(
                name: "IX_OverView_CreatedUserId",
                table: "OverView",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OverView_DeletedUserId",
                table: "OverView",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OverView_LastModifiedUserId",
                table: "OverView",
                column: "LastModifiedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OverView_AspNetUsers_CreatedUserId",
                table: "OverView",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OverView_AspNetUsers_DeletedUserId",
                table: "OverView",
                column: "DeletedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OverView_AspNetUsers_LastModifiedUserId",
                table: "OverView",
                column: "LastModifiedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OverView_AspNetUsers_CreatedUserId",
                table: "OverView");

            migrationBuilder.DropForeignKey(
                name: "FK_OverView_AspNetUsers_DeletedUserId",
                table: "OverView");

            migrationBuilder.DropForeignKey(
                name: "FK_OverView_AspNetUsers_LastModifiedUserId",
                table: "OverView");

            migrationBuilder.DropIndex(
                name: "IX_OverView_CreatedUserId",
                table: "OverView");

            migrationBuilder.DropIndex(
                name: "IX_OverView_DeletedUserId",
                table: "OverView");

            migrationBuilder.DropIndex(
                name: "IX_OverView_LastModifiedUserId",
                table: "OverView");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "OverView");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OverView");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "OverView");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OverView");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OverView");

            migrationBuilder.DropColumn(
                name: "IsSystem",
                table: "OverView");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "OverView");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "OverView");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CreationDate", "LastModifiedDate", "SurName" },
                values: new object[] { new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3068), new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3069), "Developer" });

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
                columns: new[] { "CreationDate", "FinancialYearEnd", "FinancialYearStart", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3279), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 30, 20, 22, 19, 92, DateTimeKind.Local).AddTicks(3265) });

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
        }
    }
}
