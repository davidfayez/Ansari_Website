using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ansari_Website.Infrastructure.Migrations
{
    public partial class AddSurveyQuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Survey_Answer_AnswerId",
                table: "Survey");

            migrationBuilder.DropForeignKey(
                name: "FK_Survey_Question_QuestionId",
                table: "Survey");

            migrationBuilder.DropIndex(
                name: "IX_Survey_AnswerId",
                table: "Survey");

            migrationBuilder.DropIndex(
                name: "IX_Survey_QuestionId",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Survey");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "Survey",
                type: "nvarchar(750)",
                maxLength: 750,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SurveyQuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestionAnswer_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyQuestionAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyQuestionAnswer_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id");
                });

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
                name: "IX_SurveyQuestionAnswer_AnswerId",
                table: "SurveyQuestionAnswer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionAnswer_QuestionId",
                table: "SurveyQuestionAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionAnswer_SurveyId",
                table: "SurveyQuestionAnswer",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyQuestionAnswer");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "Survey",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(750)",
                oldMaxLength: 750,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Survey",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Survey",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Survey_AnswerId",
                table: "Survey",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_QuestionId",
                table: "Survey",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Survey_Answer_AnswerId",
                table: "Survey",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Survey_Question_QuestionId",
                table: "Survey",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
