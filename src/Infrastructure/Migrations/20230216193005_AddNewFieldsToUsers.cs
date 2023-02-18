using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class AddNewFieldsToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_AspNetUsers_CreatedUserId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_AspNetUsers_DeletedUserId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_AspNetUsers_LastModifiedUserId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Department_DepartmentId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Department_CreatedUserId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_DeletedUserId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_LastModifiedUserId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Department");

            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "Survey",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsShow",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Department_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Department_DepartmentId",
                table: "Doctor",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Department_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Department_DepartmentId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsViewed",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsShow",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserId",
                table: "Department",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "Department",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "Department",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "07aced12-a30c-4998-87aa-70cf9036ceaa");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9184), new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9004), new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9004) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9167), new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9168) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9154), new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9149) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9226), new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9226) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9213), new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9214) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9241), new DateTime(2023, 2, 11, 0, 51, 37, 599, DateTimeKind.Local).AddTicks(9241) });

            migrationBuilder.CreateIndex(
                name: "IX_Department_CreatedUserId",
                table: "Department",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DeletedUserId",
                table: "Department",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_LastModifiedUserId",
                table: "Department",
                column: "LastModifiedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_AspNetUsers_CreatedUserId",
                table: "Department",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_AspNetUsers_DeletedUserId",
                table: "Department",
                column: "DeletedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_AspNetUsers_LastModifiedUserId",
                table: "Department",
                column: "LastModifiedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Department_DepartmentId",
                table: "Doctor",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }
    }
}
