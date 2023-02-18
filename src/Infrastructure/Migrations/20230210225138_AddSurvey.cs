using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class AddSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", maxLength: 5, nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
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
                    table.PrimaryKey("PK_Survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Survey_AspNetUsers_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Survey_AspNetUsers_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Survey_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Survey_AnswerId",
                table: "Survey",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_CreatedUserId",
                table: "Survey",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_DeletedUserId",
                table: "Survey",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_LastModifiedUserId",
                table: "Survey",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_QuestionId",
                table: "Survey",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63998b7d-6724-49a6-8488-0798f13726d5",
                column: "ConcurrencyStamp",
                value: "79b54d47-0f3f-4f63-9c85-5273114db48e");

            migrationBuilder.UpdateData(
                table: "AspNetUserDefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1222), new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1222) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e46158f-44e1-4e78-8101-8a4617d5daba",
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1010), new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1011) });

            migrationBuilder.UpdateData(
                table: "DefBranch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1205), new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1205) });

            migrationBuilder.UpdateData(
                table: "DefCompany",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1188), new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1183) });

            migrationBuilder.UpdateData(
                table: "DefCountry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1255), new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1256) });

            migrationBuilder.UpdateData(
                table: "DefCurrency",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1246), new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1246) });

            migrationBuilder.UpdateData(
                table: "DefReligion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1269), new DateTime(2023, 2, 3, 15, 1, 16, 617, DateTimeKind.Local).AddTicks(1270) });
        }
    }
}
